using Quarantine.Core.Models;
using Quarantine.Core.Repositories;

namespace Quarantine.Data.Repositories
{
    public class AuthorRepository: GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(QuarantineDbContext dbContext) : base(dbContext)
        {
        }
    }
}