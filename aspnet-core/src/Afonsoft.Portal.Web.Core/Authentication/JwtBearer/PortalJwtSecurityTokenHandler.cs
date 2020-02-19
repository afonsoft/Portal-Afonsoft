using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Abp;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Runtime.Caching;
using Abp.Threading;
using Microsoft.IdentityModel.Tokens;
using Afonsoft.Portal.Authorization.Users;

namespace Afonsoft.Portal.Web.Authentication.JwtBearer
{
    public class PortalJwtSecurityTokenHandler : ISecurityTokenValidator
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public PortalJwtSecurityTokenHandler()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; } = TokenValidationParameters.DefaultMaximumTokenSizeInBytes;

        public bool CanReadToken(string securityToken)
        {
            return _tokenHandler.CanReadToken(securityToken);
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            var cacheManager = IocManager.Instance.Resolve<ICacheManager>();
            var settingManager = IocManager.Instance.Resolve<ISettingManager>();
            
            var principal = _tokenHandler.ValidateToken(securityToken, validationParameters, out validatedToken);

            if (!HasAccessTokenType(principal))
            {
                throw new SecurityTokenException("invalid token type");
            }

            AsyncHelper.RunSync(() => ValidateSecurityStampAsync(settingManager, principal));

            var tokenValidityKeyClaim = principal.Claims.First(c => c.Type == AppConsts.TokenValidityKey);
            if (TokenValidityKeyExistsInCache(tokenValidityKeyClaim, cacheManager))
            {
                return principal;
            }

            var userIdentifierString = principal.Claims.First(c => c.Type == AppConsts.UserIdentifier);
            var userIdentifier = UserIdentifier.Parse(userIdentifierString.Value);

            if (!ValidateTokenValidityKey(tokenValidityKeyClaim, userIdentifier))
            {
                throw new SecurityTokenException("invalid");
            }

            var tokenAuthConfiguration = IocManager.Instance.Resolve<TokenAuthConfiguration>();
            cacheManager
                .GetCache(AppConsts.TokenValidityKey)
                .Set(tokenValidityKeyClaim.Value, "", absoluteExpireTime: tokenAuthConfiguration.AccessTokenExpiration);

            return principal;
        }

        private bool ValidateTokenValidityKey(Claim tokenValidityKeyClaim, UserIdentifier userIdentifier)
        {
            bool isValid;

            using (var unitOfWorkManager = IocManager.Instance.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = unitOfWorkManager.Object.Begin())
                {
                    using (unitOfWorkManager.Object.Current.SetTenantId(userIdentifier.TenantId))
                    {
                        using (var userManager = IocManager.Instance.ResolveAsDisposable<UserManager>())
                        {
                            var userManagerObject = userManager.Object;
                            var user = userManagerObject.GetUser(userIdentifier);
                            isValid = AsyncHelper.RunSync(() => userManagerObject.IsTokenValidityKeyValidAsync(user, tokenValidityKeyClaim.Value));

                            uow.Complete();
                        }
                    }
                }
            }

            return isValid;
        }

        private static bool TokenValidityKeyExistsInCache(Claim tokenValidityKeyClaim, ICacheManager cacheManager)
        {
            var tokenValidityKeyInCache = cacheManager
                .GetCache(AppConsts.TokenValidityKey)
                .GetOrDefault(tokenValidityKeyClaim.Value);

            return tokenValidityKeyInCache != null;
        }

        private static async Task ValidateSecurityStampAsync(ISettingManager settingManager, ClaimsPrincipal principal)
        {
            using (var securityStampHandler = IocManager.Instance.ResolveAsDisposable<IJwtSecurityStampHandler>())
            {
                if (!await securityStampHandler.Object.Validate(principal))
                {
                    throw new SecurityTokenException("invalid");
                }
            }
        }

        private bool HasAccessTokenType(ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(x => x.Type == AppConsts.TokenType)?.Value ==
                   TokenType.AccessToken.To<int>().ToString();
        }
    }
}
