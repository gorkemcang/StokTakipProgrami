using StokTakipProgrami.Entity;
using StokTakipProgrami.Database;

namespace StokTakipProgrami.Concrate
{
	public class ProductsManager(Context context)
    {
		ProductsManager _productsManager;
		private readonly Context _context = context;

        public List<Product> GetListProduct()
		{
			return _context.Products.ToList();
		}

		public Product GetProductById(int id)
		{
			return _context.Products.FirstOrDefault(p => p.Id == id);
		}

		public void AddProduct(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
		}

		public void UpdateProduct(Product product)
		{
			_context.Products.Update(product);
			_context.SaveChanges();
		}

		public void DeleteProduct(Product product)
		{
			_context.Products.Remove(product);
			_context.SaveChanges();
		}
	}
}
