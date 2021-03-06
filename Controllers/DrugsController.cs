using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Viruses.Models;

namespace Viruses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : Controller
    {
        //private readonly VirusContext _context;
        IRepository repository;

        public DrugController(IRepository r)
        {
            repository = r;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        [HttpPost]
        public IActionResult AddDrug(Drug drug)
        {
            if (ModelState.IsValid)
            {
                repository.Create(drug);
                return RedirectToAction("Index");
            }
            return View(drug);
        }

        /*// GET: api/Drugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrug()
        {
            return await _context.Drug.ToListAsync();
        }*/
        [HttpGet]
        public IActionResult GetDrug(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            Drug drug = repository.Get(id.Value);
            if (drug == null)
                return NotFound();
            return View(drug);
        }

        public IActionResult AddUser() => View();

        [HttpPost]
        public IActionResult AddGrug(Drug drug)
        {
            if (ModelState.IsValid)
            {
                repository.Create(drug);
                return RedirectToAction("Index");
            }
            return View(drug);
        }
        /*// GET: api/Drugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrug(int id)
        {
            var drug = await _context.Drug.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            return drug;
        }*/

        // PUT: api/Drugs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutDrug(int id, Drug drug)
        {
            if (id != drug.Id)
            {
                return BadRequest();
            }
            _context.Entry(drug).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }*/

        // POST: api/Drugs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /* [HttpPost]
        public async Task<ActionResult<Drug>> PostDrug(Drug drug)
        {
            _context.Drug.Add(drug);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDrug", new { id = drug.Id }, drug);
        }*/
        /*
        // DELETE: api/Drugs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drug>> DeleteDrug(int id)
        {
            var drug = await _context.Drug.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            _context.Drug.Remove(drug);
            await _context.SaveChangesAsync();
            return drug;
        }
        private bool DrugExists(int id)
        {
            return _context.Drug.Any(e => e.Id == id);
        }*/
    }
}
