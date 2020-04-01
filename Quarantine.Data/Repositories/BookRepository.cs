using Quarantine.Core.Models;
using Quarantine.Core.Repositories;

namespace Quarantine.Data.Repositories
{
    public class BookRepository: GenericRepository<Book>, IBookRepository
    {
        public BookRepository(QuarantineDbContext dbContext) : base(dbContext)
        {
        }
    }
}