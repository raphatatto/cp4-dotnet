namespace cp.Data
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string LivroCollectionName { get; set; } = "Livros";

    }
}
