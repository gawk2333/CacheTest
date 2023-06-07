using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CacheTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;

        public BookController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetBookById(long id) {
            /*
            Book? result = DbContext.GetById(id);
            if (result == null)
            {
                return NotFound($"Can' find the book id={id}");
            }
            else
            {
                return Ok(result);
            }
            */
            Console.WriteLine("Start running get book id");
            Book? b = await memoryCache.GetOrCreateAsync("Book" + id, async (e) =>
            {
                Console.WriteLine("reading from db");
                return await DbContext.GetByIdAsync(id);
            });
            if (b == null)
            {
                return NotFound();
            } else
            {
                Console.WriteLine($"Book {b}");
                return b;
            }
        }
    }
}
