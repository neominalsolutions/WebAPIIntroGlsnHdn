using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Logging;
using Microsoft.EntityFrameworkCore;
using WebAPIIntro.Data;
using WebAPIIntro.Data.Entities;
using WebAPIIntro.Dtos;

namespace WebAPIIntro.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    //private readonly ApplicationContext _context =  new ApplicationContext();

    private readonly ApplicationContext _context;
    private readonly WebAPIIntro.Services.ConsoleLogger _consoleLogger;
    public CategoriesController(ApplicationContext context, WebAPIIntro.Services.ConsoleLogger consoleLogger) // dependency injection ile instance program dosyasında AddDbContext ile sistene register edilip bütun uygulama genelinde instance istenen yerlerde contructor'a parametre olarak geçilebilir.
    {

      //using (ApplicationContext c = new ApplicationContext())
      //{

      //}

      // referansı elimizdeki nesneye eşitleedik.
      _consoleLogger = consoleLogger;

      _context = context;
    }

    // GET: api/Categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
      _consoleLogger.Log("console");


      if (_context.Categories == null)
      {
        return NotFound();
      }

      // EF eager loading yerine lazy loading geldi.
      var plist = await _context.Categories.Include(x => x.Products).ToListAsync();

      // auto mapper

      var model = plist.Select(a => new CategoryDto
      {
        Id = a.Id,
        Name = a.Name,
        Products = a.Products.Select(p=> new ProductDto
        {
          Id = p.Id,
          Name = p.Name

        }).ToList()
      }).ToList();

      return Ok(model);

    }

    // GET: api/Categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Data.Entities.Category>> GetCategory(int id)
    {
      if (_context.Categories == null)
      {
        return NotFound();
      }
      var category = await _context.Categories.FindAsync(id);

      if (category == null)
      {
        return NotFound();
      }

      return category;
    }

    // PUT: api/Categories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, Data.Entities.Category category)
    {
      if (id != category.Id)
      {
        return BadRequest();
      }

      _context.Entry(category).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CategoryExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Categories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Data.Entities.Category>> PostCategory(Data.Entities.Category category)
    {
      if (_context.Categories == null)
      {
        return Problem("Entity set 'ApplicationContext.Categories'  is null.");
      }
      _context.Categories.Add(category);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCategory", new { id = category.Id }, category);
    }

    // DELETE: api/Categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
      if (_context.Categories == null)
      {
        return NotFound();
      }
      var category = await _context.Categories.FindAsync(id);
      if (category == null)
      {
        return NotFound();
      }

      _context.Categories.Remove(category);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool CategoryExists(int id)
    {
      return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
