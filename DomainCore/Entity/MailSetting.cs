using System;
using System.Collections.Generic;


namespace DominCore.Entity
{
    public class MailSetting:BaseEntity
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string DisplayName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public bool IsActive { get; set; }
    }
}
