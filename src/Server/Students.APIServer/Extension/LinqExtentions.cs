namespace Students.APIServer.Extension
{
	/// <summary>
	/// Раширение языка запросов
	/// </summary>
	public static class LinqExtentions
	{
		/// <summary>
		/// Асинронный запрос
		/// </summary>
		/// <typeparam name="TSource">Источник данных</typeparam>
		/// <typeparam name="TResult">Результат</typeparam>
		/// <param name="source">Источник данных</param>
		/// <param name="method">Функция, которую нужно выполнить</param>
		/// <returns>Список объектов</returns>
		public static async Task<IEnumerable<TResult>> SelectAsync<TSource, TResult>(
			this IEnumerable<TSource> source, Func<TSource, Task<TResult>> method)
		{
			return await Task.WhenAll(source.Select(async s => await method(s)));
		}
	}
}
