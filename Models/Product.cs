using EMallMVC.Data;
using System.ComponentModel.DataAnnotations;

namespace EMallMVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductDescription { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Decimal ? Price { get; set; }
    }
}
