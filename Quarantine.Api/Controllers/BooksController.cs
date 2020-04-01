using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quarantine.Core.Models;
using Quarantine.Core.Services;

namespace Quarantine.Api.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [Route("")]
        [HttpGet]
        public async Task<ICollection<Book>> Get()
        {
            return await _bookService.GetAllAsync();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<Book> GetAll(Guid id)
        {
            return await _bookService.GetAsync(id);
        }

        [Route("")]
        [HttpPost]
        public async Task<Book> Add([FromBody] Book author)
        {
            return await _bookService.AddAsync(author);
        }

        [Route("{id}")]
        [HttpPost]
        public async Task<Book> Update(Guid id, [FromBody] Book author)
        {
            return await _bookService.AddAsync(author);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task Update(Guid id)
        {
            await _bookService.RemoveAsync(new Book {Id = id});
        }
    }
}