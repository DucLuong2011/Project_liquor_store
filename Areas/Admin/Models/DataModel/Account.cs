using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_WAD.Areas.Admin.Models.DataModel
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ không được để trống")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 ký tự")]
        [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 ký tự")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]

        public string Email { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

    }
}
