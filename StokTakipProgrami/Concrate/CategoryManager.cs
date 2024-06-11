using StokTakipProgrami.Entity;
using StokTakipProgrami.Database;

namespace StokTakipProgrami.Concrate
{
	public class CategoryManager
	{
		private readonly Context _context;

		public CategoryManager(Context context)
		{
			_context = context;
		}

		public List<Category> GetListCategory()
		{
			return _context.Categories.ToList();
		}

		public Category GetCategoryById(int id)
		{
			return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
		}

		public void AddCategory(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
		}

		public void UpdateCategory(Category category)
		{
			_context.Categories.Update(category);
			_context.SaveChanges();
		}

		public void DeleteCategory(Category category)
		{
			_context.Categories.Remove(category);
			_context.SaveChanges();
		}

		public static implicit operator CategoryManager(ProductsManager v)
		{
			throw new NotImplementedException();
		}
	}
}
