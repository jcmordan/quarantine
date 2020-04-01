using Quarantine.Core.Models;
using Quarantine.Core.Repositories;

namespace Quarantine.Core.Services
{
    public class AuthorService: GenericService<Author>
    {
        public AuthorService(IAuthorRepository repository) : base(repository)
        {
        }
    }
}
