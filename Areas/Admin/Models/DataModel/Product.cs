using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_WAD.Areas.Admin.Models.DataModel
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public string Image { get; set; }
        [Required]
        public float Price { get; set; }
        public float SalePrice { get; set; }
        public byte Status { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        // khóa ngoại tới bảng Category
        public Category Category { get; set; }
    }

}
