using System.ComponentModel.DataAnnotations;

namespace StokTakipProgrami.Entity
{
	public class Category
	{
		[Key]
        public int CategoryId { get; set; }
		public required string CategoryName { get; set; } =  "";
    }
}
