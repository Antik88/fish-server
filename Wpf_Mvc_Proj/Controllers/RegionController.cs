using Microsoft.AspNetCore.Mvc;
using ApplicationDbContextNs;
using Wpf_Mvc_Proj.Models;
using Microsoft.EntityFrameworkCore;

namespace Regions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Region
        [HttpGet]
        public IActionResult GetRegions()
        {
            var regions = _context.Regions.ToList();
            return Ok(regions);
        }

        // GET: api/Region/{id}
        [HttpGet("{id}")]
        public IActionResult GetRegion(int id)
        {
            var region = _context.Regions.FirstOrDefault(r => r.RegionId == id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        // POST: api/Region
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] Region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Regions.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegion), new { id = region.RegionId }, region);
        }

        // PUT: api/Region/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(int id, [FromBody] Region region)
        {
            if (region == null)
            {
                return BadRequest("Некорректные данные.");
            }

            var existingRegion = await _context.Regions
                .FirstOrDefaultAsync(r => r.RegionId == id);

            if (existingRegion == null)
            {
                return NotFound($"Регион с ID {id} не найден.");
            }

            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.City = region.City;
            existingRegion.Latitude = region.Latitude;
            existingRegion.Longitude = region.Longitude;
            existingRegion.HabitatInfo = region.HabitatInfo;
            existingRegion.EnvironmentalQualityId = region.EnvironmentalQualityId;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Region/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var region = _context.Regions.FirstOrDefault(r => r.RegionId == id);

            if (region == null)
            {
                return NotFound();
            }

            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
