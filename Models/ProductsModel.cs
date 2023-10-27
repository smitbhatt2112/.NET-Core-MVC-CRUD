using System.ComponentModel.DataAnnotations;

namespace Project_Management.Models
{
    public class ProductsModel
    {
        public int? ProductId { get; set; }
        [Required(ErrorMessage= "Product Name Required")]
        public string? ProductName { get; set; }
        [Required(ErrorMessage = "Product ProductBrand Required")]
        public string? ProductBrand { get; set; }
        [Required(ErrorMessage = "Product ProductManufacturer Required")]
        public string? ProductManufacturer { get; set; }
    }
}
