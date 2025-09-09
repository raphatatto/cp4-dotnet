using cp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using cp.Data;
using MongoDB.Bson;
namespace cp.Service
{
    public class LivroService
    {
        private readonly IMongoCollection<Livro> _livros;

        public LivroService(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var db = client.GetDatabase(options.Value.DatabaseName);
            _livros = db.GetCollection<Livro>(options.Value.LivroCollectionName);
        }

        // LISTAR TODOS
        public async Task<List<Livro>> GetAllAsync() =>
            await _livros.Find(_ => true).ToListAsync();

        // OBTER 1 POR ID
        public async Task<Livro?> GetAsync(string id) =>
            await _livros.Find(l => l.Id == id).FirstOrDefaultAsync();

        // CRIAR
        public async Task CreateAsync(Livro livro)
        {
        if (string.IsNullOrWhiteSpace(livro.Id))
            livro.Id = ObjectId.GenerateNewId().ToString();

        await _livros.InsertOneAsync(livro);
        }

        // ATUALIZAR (substitui documento inteiro)
        public async Task UpdateAsync(string id, Livro livroAtualizado)
        {
            livroAtualizado.Id = id;
            await _livros.ReplaceOneAsync(l => l.Id == id, livroAtualizado);
        }

        // EXCLUIR
        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _livros.DeleteOneAsync(l => l.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
