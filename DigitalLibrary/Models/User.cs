using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Models
{
    public class User : IdentityUser
    {
        [Required]
        [Display(Name ="نام")]
        [MaxLength(250)]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "شماره همراه")]
        [MaxLength(16)]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
    }
}
