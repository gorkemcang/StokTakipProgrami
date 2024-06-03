using StokTakipProgrami.Entity;

namespace StokTakipProgrami.Abstracts
{
	public interface IProductsServices : IGenericServices<Product>
	{
		void GetProductById(Product t);
	}
}
