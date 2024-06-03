using System.ComponentModel.DataAnnotations;

namespace StokTakipProgrami.Entity
{
	public class Product
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
