using System.ComponentModel.DataAnnotations;

namespace Project_WAD.Areas.Admin.Models.DataModel
{
    public class Login
    {
        [Required(ErrorMessage = "Địa chỉ email không để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không để trống")]
        public string Password { get; set; }
        public string Avatar { get; set; }
        public bool Remember { get; set; }

    }
}
