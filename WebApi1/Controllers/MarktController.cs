using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarktController : ControllerBase
    {
        private readonly WareContext _context;

        public MarktController(WareContext context)
        {
            _context = context;

            if (_context.Waren.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Waren.Add(new Ware { Name = "Ware1", ShortName = "EIN" });
                _context.Waren.Add(new Ware { Name = "Ware2", ShortName = "ZWO" });
                _context.Waren.Add(new Ware { Name = "Ware3", ShortName = "TRI" });
                _context.SaveChanges();
            }
        }

        // GET: api/Markt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ware>>> GetWaren()
        {
            return await _context.Waren.ToListAsync();
        }

        // GET: api/Markt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ware>> GetWare(long id)
        {
            var Ware = await _context.Waren.FindAsync(id);

            if (Ware == null)
            {
                return NotFound();
            }

            return Ware;
        }

    }
}
