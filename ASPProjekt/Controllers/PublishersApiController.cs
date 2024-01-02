using BookData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace ASPProjekt.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublishersApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PublishersApiController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]
        public IActionResult GetPublishersByName(string? name)
        {
            if (string.IsNullOrEmpty(name))
                return Ok(_context.Publishers.ToList());

            var filteredPublishers = _context.Publishers
                .Where(x => EF.Functions.Like(x.Name, $"{name}%"))
                .Select(y => new { Name = y.Name, Id = y.Id })
                .ToList();

            return Ok(filteredPublishers);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var entity = _context.Publishers.Find(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

    }
}
