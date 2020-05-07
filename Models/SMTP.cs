using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuptaAccounting.Models
{
    public class SMTP
    {
        [Required]
        [DisplayName("Email From Name")]
        public string EmailFromName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email From")]
        public string EmailFrom { get; set; }

        [Required]
        [DisplayName("Email To Name")]
        public string EmailToName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email To")]
        public string EmailTo { get; set; }

        [Key]
        [Required]
        [DisplayName("ServerName")]
        public string ServerName { get; set; }

        [Required]
        [DisplayName("SMTP Server Address")]
        public string ServerAddress { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("SMTP Authentication Email")]
        public string AuthenticationEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("SMTP Authentication Password")]
        public string AuthenticationPassword { get; set; }

        [Required]
        [DisplayName("SMTP Port Number")]
        public int PortNumber { get; set; }

        [Required]
        [DisplayName("SSL Required")]
        public bool SSLRequired { get; set; }
    }
}
