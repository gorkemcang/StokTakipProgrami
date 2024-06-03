using StokTakipProgrami.Entity;

namespace StokTakipProgrami.Abstracts
{
	public interface ICategoryServices : IGenericServices<Category>
	{
		void GetByCategoryId(Category category);
	}
}
