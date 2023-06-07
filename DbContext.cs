namespace CacheTest
{
    public class DbContext
    {
        public static Task<Book?> GetByIdAsync (long id)
        {
            var result = GetById(id);
            return Task.FromResult(result);
        }
        public static Book? GetById(long Id)
        {
            switch (Id)
            {
                case 0:
                    return new Book(0, "book 0");
                case 1:
                    return new Book(1, "book 1");
                case 2:
                    return new Book(2, "book 2");
                default:
                    return null;

            }
        }
    }
}
