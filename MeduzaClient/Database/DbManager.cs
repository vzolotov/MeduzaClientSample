using MeduzaClient.Services.Database;
using System.Threading.Tasks;

namespace MeduzaClient.Database
{
    internal class DbManager : IDbManager
    {
        private DataContext _ctx;
        public DbManager(DataContext context)
        {
            _ctx = context;
        }
        public async Task DeleteDatabase()
        {
            await _ctx.Database.EnsureDeletedAsync();
        }

        public async Task CreateDatabase()
        {
            IsDbCreated = await _ctx.Database.EnsureCreatedAsync();
        }

        public bool IsDbCreated { get; set; }
    }
}
