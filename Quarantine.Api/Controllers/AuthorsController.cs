using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quarantine.Core.Models;
using Quarantine.Core.Services;

namespace Quarantine.Api.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [Route("")]
        [HttpGet]
        public async Task<ICollection<Author>> Get()
        {
            return await _authorService.GetAllAsync();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<Author> GetAll(Guid id)
        {
            return await _authorService.GetAsync(id);
        }

        [Route("")]
        [HttpPost]
        public async Task<Author> Add([FromBody] Author author)
        {
            return await _authorService.AddAsync(author);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<Author> Update(Guid id, [FromBody] Author author)
        {
            return await _authorService.AddAsync(author);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task Update(Guid id)
        {
            await _authorService.RemoveAsync(new Author {Id = id});
        }
    }
}