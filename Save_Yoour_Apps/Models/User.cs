using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Save_Yoour_Apps.Models
{
    public class User
    {
        public User()
        {
        }    
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указана почта")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }="";
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }="";
    }
}
