using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_WAD.Areas.Admin.Models.DataModel
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ không được để trống")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 ký tự")]
        [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 ký tự")]
        public string FullName { get; set; }

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        public string Email { get; set; }

        [Display(Name = "Số ĐT")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(35, ErrorMessage = "Địa chỉ không vượt quá 35 ký tự")]
        public string Address { get; set; }

        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
    }

}
