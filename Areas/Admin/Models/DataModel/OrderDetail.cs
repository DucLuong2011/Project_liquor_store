using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_WAD.Areas.Admin.Models.DataModel
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        // Khóa ngoại tới Orders
        public Orders Order { get; set; }
        // Khóa ngoại tới Product
        public Product Product { get; set; }
    }

}
