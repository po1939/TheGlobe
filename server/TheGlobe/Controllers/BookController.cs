using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheGlobeServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        // GET: api/Book
        [HttpGet, AllowAnonymous]
        public async Task<IEnumerable<BookDto>> Get()
        {
            return await _bookService.Get();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<BookDto> Get(int id)
        {
            return await _bookService.Get(id);
        }

        //// POST: api/Book
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Book/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
