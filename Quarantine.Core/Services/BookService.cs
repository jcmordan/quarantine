using Quarantine.Core.Models;
using Quarantine.Core.Repositories;

namespace Quarantine.Core.Services
{
    public class BookService: GenericService<Book>
    {
        public BookService(IBookRepository repository) : base(repository)
        {
        }
    }
}
