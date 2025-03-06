using Microsoft.AspNetCore.Mvc;
using ApplicationDbContextNs;
using Wpf_Mvc_Proj.Models;
using Microsoft.EntityFrameworkCore;

namespace EnvironmentalQualitys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvironmentalQualityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnvironmentalQualityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EnvironmentalQuality
        [HttpGet]
        public IActionResult GetEnvironmentalQualities()
        {
            var environmentalQualities = _context.EnvironmentalQualities.ToList();
            
            return Ok(environmentalQualities);
        }

        // GET: api/EnvironmentalQuality/{id}
        [HttpGet("{id}")]
        public IActionResult GetEnvironmentalQuality(int id)
        {
            var environmentalQuality = _context.EnvironmentalQualities.FirstOrDefault(eq => eq.QualityId == id);

            if (environmentalQuality == null)
            {
                return NotFound();
            }

            return Ok(environmentalQuality);
        }

        // POST: api/EnvironmentalQuality
        [HttpPost]
        public async Task<IActionResult> CreateEnvironmentalQuality([FromBody] EnvironmentalQuality environmentalQuality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EnvironmentalQualities.Add(environmentalQuality);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnvironmentalQuality), new { id = environmentalQuality.QualityId }, environmentalQuality);
        }

        // PUT: api/EnvironmentalQuality/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnvironmentalQuality(int id, [FromBody] EnvironmentalQuality environmentalQuality)
        {
            if (environmentalQuality == null)
            {
                return BadRequest("Некорректные данные.");
            }

            var existingEnvironmentalQuality = await _context.EnvironmentalQualities
                .FirstOrDefaultAsync(eq => eq.QualityId == id);

            if (existingEnvironmentalQuality == null)
            {
                return NotFound($"Объект с ID {id} не найден.");
            }

            existingEnvironmentalQuality.RegionId = environmentalQuality.RegionId;
            existingEnvironmentalQuality.PollutionLevel = environmentalQuality.PollutionLevel;
            existingEnvironmentalQuality.Pollutants = environmentalQuality.Pollutants;
            existingEnvironmentalQuality.AssessmentDate = environmentalQuality.AssessmentDate;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/EnvironmentalQuality/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvironmentalQuality(int id)
        {
            var environmentalQuality = _context.EnvironmentalQualities.FirstOrDefault(eq => eq.QualityId == id);

            if (environmentalQuality == null)
            {
                return NotFound();
            }

            _context.EnvironmentalQualities.Remove(environmentalQuality);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
