namespace Project_Management.Models
{
    public class Product_DetailsModel
    {
        public int? Product_Details_Id { get; set; }
        public int? ProductId { get; set; }
        public string? ProductVarient { get; set; }
        public string? ProductColor { get; set; }
        public string? ProductDes { get; set; }
        public decimal? ProductCost { get; set; }
        public decimal? ProductSalePrice { get; set; }
        public IFormFile? File { get; set; }
        public string? PhotoPath { get; set; }

    }
}
