﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Abp.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetZeroCore.Web.Authentication.External;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Abp.Authorization;
using System.Linq;
using Abp.Runtime.Security;
using Microsoft.AspNetCore.Hosting;
using Afonsoft.Portal.Configuration;
using Afonsoft.Portal.Web.Authentication.JwtBearer;

namespace Afonsoft.Portal.Web.Startup
{
    public static class AuthConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var authenticationBuilder = services.AddAuthentication();
            if (bool.Parse(configuration["Authentication:OpenId:IsEnabled"]))
            {
                authenticationBuilder.AddOpenIdConnect(options =>
                {
                    options.ClientId = configuration["Authentication:OpenId:ClientId"];
                    options.Authority = configuration["Authentication:OpenId:Authority"];
                    options.SignedOutRedirectUri = configuration["App:WebSiteRootAddress"] + "Account/Logout";
                    options.ResponseType = OpenIdConnectResponseType.IdToken;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = bool.Parse(configuration["Authentication:OpenId:ValidateIssuer"])
                    };

                    options.Events.OnTokenValidated = context =>
                    {
                        var jsonClaimMappings = new List<JsonClaimMap>();
                        configuration.GetSection("Authentication:OpenId:ClaimsMapping").Bind(jsonClaimMappings);

                        context.AddMappedClaims(jsonClaimMappings);

                        return Task.FromResult(0);
                    };

                    var clientSecret = configuration["Authentication:OpenId:ClientSecret"];
                    if (!clientSecret.IsNullOrEmpty())
                    {
                        options.ClientSecret = clientSecret;
                    }
                });
            }

            if (bool.Parse(configuration["Authentication:Microsoft:IsEnabled"]))
            {
                authenticationBuilder.AddMicrosoftAccount(options =>
                {
                    options.ClientId = configuration["Authentication:Microsoft:ConsumerKey"];
                    options.ClientSecret = configuration["Authentication:Microsoft:ConsumerSecret"];
                });
            }

            if (bool.Parse(configuration["Authentication:Google:IsEnabled"]))
            {
                authenticationBuilder.AddGoogle(options =>
                {
                    options.ClientId = configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"];

                    options.UserInformationEndpoint = configuration["Authentication:Google:UserInfoEndpoint"];
                    options.ClaimActions.Clear();

                    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                    options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                });
            }

            if (bool.Parse(configuration["Authentication:Twitter:IsEnabled"]))
            {
                authenticationBuilder.AddTwitter(options =>
                {
                    options.ConsumerKey = configuration["Authentication:Twitter:ConsumerKey"];
                    options.ConsumerSecret = configuration["Authentication:Twitter:ConsumerSecret"];
                    options.RetrieveUserDetails = true;
                });
            }

            /*if (bool.Parse(configuration["Authentication:Facebook:IsEnabled"]))
            {
                authenticationBuilder.AddFacebook(options =>
                {
                    options.AppId = configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = configuration["Authentication:Facebook:AppSecret"];

                    options.Scope.Add("email");
                    options.Scope.Add("public_profile");
                });
            }

            if (bool.Parse(configuration["Authentication:WsFederation:IsEnabled"]))
            {
                authenticationBuilder.AddWsFederation(options =>
                {
                    options.MetadataAddress = configuration["Authentication:WsFederation:MetaDataAddress"];
                    options.Wtrealm = configuration["Authentication:WsFederation:Wtrealm"];
                    options.Events.OnSecurityTokenValidated = context =>
                    {
                        var jsonClaimMappings = new List<JsonClaimMap>();
                        configuration.GetSection("Authentication:WsFederation:ClaimsMapping").Bind(jsonClaimMappings);

                        context.AddMappedClaims(jsonClaimMappings);

                        return Task.FromResult(0);
                    };
                });
            }*/

            if (bool.Parse(configuration["Authentication:JwtBearer:IsEnabled"]))
            {
                authenticationBuilder.AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // The signing key must match!
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"])),

                        // Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Authentication:JwtBearer:Issuer"],

                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = configuration["Authentication:JwtBearer:Audience"],

                        // Validate the token expiry
                        ValidateLifetime = true,

                        // If you want to allow a certain amount of clock drift, set that here
                        ClockSkew = TimeSpan.FromMinutes(300)
                    };

                    options.RefreshOnIssuerKeyNotFound = true;
                    options.SecurityTokenValidators.Clear();
                    options.SecurityTokenValidators.Add(new PortalJwtSecurityTokenHandler());

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = QueryStringTokenResolver
                    };
                });
            }

            if (bool.Parse(configuration["IdentityServer:IsEnabled"]))
            {
                authenticationBuilder.AddIdentityServerAuthentication("IdentityBearer", options =>
                {
                    options.Authority = configuration["IdentityServer:Authority"];
                    options.ApiName = configuration["IdentityServer:ApiName"];
                    options.ApiSecret = configuration["IdentityServer:ApiSecret"];
                    options.RequireHttpsMetadata = false;
                    options.CacheDuration = TimeSpan.FromMinutes(30);
                    options.EnableCaching = true;
                });
            }
        }

        /* This method is needed to authorize SignalR javascript client.
        * SignalR can not send authorization header. So, we are getting it from query string as an encrypted text. */
        private static Task QueryStringTokenResolver(MessageReceivedContext context)
        {
            if (!context.HttpContext.Request.Path.HasValue)
            {
                return Task.CompletedTask;
            }

            if (context.HttpContext.Request.Path.Value.StartsWith("/signalr"))
            {
                var env = context.HttpContext.RequestServices.GetService<IWebHostEnvironment>();
                var config = env.GetAppConfiguration();
                var allowAnonymousSignalRConnection = bool.Parse(config["App:AllowAnonymousSignalRConnection"]);

                return SetToken(context, allowAnonymousSignalRConnection);
            }

            if (context.HttpContext.Request.Path.Value.Contains("/Chat/GetUploadedObject"))
            {
                return SetToken(context, false);
            }

            return Task.CompletedTask;
        }

        private static Task SetToken(MessageReceivedContext context, bool allowAnonymous)
        {
            var qsAuthToken = context.HttpContext.Request.Query["enc_auth_token"].FirstOrDefault();
            if (qsAuthToken == null)
            {
                if (!allowAnonymous)
                {
                    throw new AbpAuthorizationException("SignalR auth token is missing.");
                }

                return Task.CompletedTask;
            }

            //Set auth token from cookie
            context.Token = SimpleStringCipher.Instance.Decrypt(qsAuthToken, AppConsts.DefaultPassPhrase);
            return Task.CompletedTask;
        }
    }
}
