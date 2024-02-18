using crudWithReact.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudWithReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
           var books = _context.Books;
           return Ok(books);
        }
        [HttpGet("Get-ById")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.Find(id);
            return Ok(book);
        }


        [HttpPost]
        public IActionResult Add([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(200);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges(); 
            return Ok(200);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            _context.Remove(book);
            _context.SaveChanges();
            return Ok(200);
        }
    }
}
