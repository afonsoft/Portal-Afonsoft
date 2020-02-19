﻿using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Afonsoft.Portal.MultiTenancy.Payments;
using Afonsoft.Portal.MultiTenancy.Payments.Dto;

namespace Afonsoft.Portal.MultiTenancy.Dto
{
    public class RegisterTenantInput
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string AdminPassword { get; set; }

        [DisableAuditing]
        public string CaptchaResponse { get; set; }

        public SubscriptionStartType SubscriptionStartType { get; set; }

        public int? EditionId { get; set; }
    }
}