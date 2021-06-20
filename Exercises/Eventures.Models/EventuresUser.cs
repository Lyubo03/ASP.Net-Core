namespace Eventures.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.User;
    public class EventuresUser : IdentityUser
    {
        [Required]
        [MinLength(UsernameMinLength)]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        [Required]
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public override string Email { get => base.Email; set => base.Email = value; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [MaxLength(UCNMaxLength)]
        [MinLength(UCNMinLength)]
        public string UCN { get; set; }
    }
}