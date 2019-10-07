namespace INOM.Entities
{
    public static class DBInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
