using Microsoft.AspNetCore.Mvc;
using ApplicationDbContextNs;
using Wpf_Mvc_Proj.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesPointController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalesPointController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesPoint
        [HttpGet]
        public IActionResult GetSalesPoints()
        {
            var salesPoints = _context.SalesPoints.ToList();
            return Ok(salesPoints);
        }

        [HttpGet("region")]
        public IActionResult GetSalesPoints([FromQuery] int regionId)
        {
            var salesPoints = _context.SalesPoints
                .Where(s => s.RegionId == regionId)
                .ToList();
            return Ok(salesPoints);
        }

        // GET: api/SalesPoint/{id}
        [HttpGet("{id}")]
        public IActionResult GetSalesPoint(int id)
        {
            var salesPoint = _context.SalesPoints.FirstOrDefault(sp => sp.SalesPointId == id);

            if (salesPoint == null)
            {
                return NotFound();
            }

            return Ok(salesPoint);
        }

        // POST: api/SalesPoint
        [HttpPost]
        public async Task<IActionResult> CreateSalesPoint([FromBody] SalesPoint salesPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SalesPoints.Add(salesPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalesPoint), new { id = salesPoint.SalesPointId }, salesPoint);
        }

        // PUT: api/SalesPoint/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalesPoint(int id, [FromBody] SalesPoint salesPoint)
        {
            if (salesPoint == null)
            {
                return BadRequest("Некорректные данные.");
            }

            var existingSalesPoint = await _context.SalesPoints
                .FirstOrDefaultAsync(sp => sp.SalesPointId == id);

            if (existingSalesPoint == null)
            {
                return NotFound($"Точка продаж с ID {id} не найдена.");
            }

            existingSalesPoint.RegionId = salesPoint.RegionId;
            existingSalesPoint.Name = salesPoint.Name;
            existingSalesPoint.Address = salesPoint.Address;
            existingSalesPoint.WorkingHours = salesPoint.WorkingHours;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/SalesPoint/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesPoint(int id)
        {
            var salesPoint = _context.SalesPoints.FirstOrDefault(sp => sp.SalesPointId == id);

            if (salesPoint == null)
            {
                return NotFound();
            }

            _context.SalesPoints.Remove(salesPoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
