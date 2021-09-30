using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksServices _booksServices;
        public BooksController(BooksServices bookservices)
        {
            _booksServices = bookservices;
        }

        [HttpPost("add-books")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksServices.AddBook(book);
            return Ok();
        }
    }
}
