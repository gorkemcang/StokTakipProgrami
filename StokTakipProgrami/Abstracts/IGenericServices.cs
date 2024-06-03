namespace StokTakipProgrami.Abstracts
{
	public interface IGenericServices<T>
	{
		void TAdd(T t);
		void TRemove(T t);
		void TUpdate(T t);
		List<T> TList(T t);
		T TGetById(int id);
	}
}
