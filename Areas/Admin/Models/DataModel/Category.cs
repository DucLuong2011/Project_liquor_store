using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_WAD.Areas.Admin.Models.DataModel
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public byte Status { get; set; }
        // danh sách sản phẩm theo danh mục
        public ICollection<Product> Products { get; set; }
    }

}
