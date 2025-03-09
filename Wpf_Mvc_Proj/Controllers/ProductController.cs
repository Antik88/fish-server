using Microsoft.AspNetCore.Mvc;
using ApplicationDbContextNs;
using Wpf_Mvc_Proj.Models;
using Microsoft.EntityFrameworkCore;

namespace Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("search")]
        public IActionResult GetProductsByName([FromQuery] string name)
        {
            var products = _context.Products
                .Where(p => p.Name.Contains(name))
                .ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpGet("region/{regionId}")]
        public IActionResult GetProductsByRegion(int regionId)
        {
            var products = _context.Products.Where(p => p.OriginRegionId == regionId).ToList();

            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Некорректные данные.");
            }

            var existingProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (existingProduct == null)
            {
                return NotFound($"Продукт с ID {id} не найден.");
            }

            existingProduct.Name = product.Name;
            existingProduct.OriginRegionId = product.OriginRegionId;
            existingProduct.SelectionDate = product.SelectionDate;
            existingProduct.WeightProduct = product.WeightProduct;
            existingProduct.ExpirationDate = product.ExpirationDate;
            existingProduct.LengthTL = product.LengthTL;
            existingProduct.LengthSl = product.LengthSl;
            existingProduct.LengthFl = product.LengthFl;
            existingProduct.K = product.K;
            existingProduct.MnUgKg = product.MnUgKg;
            existingProduct.MnUgKgSy = product.MnUgKgSy;
            existingProduct.CoUgKg = product.CoUgKg;
            existingProduct.CoUgKgSy = product.CoUgKgSy;
            existingProduct.NiUgKg = product.NiUgKg;
            existingProduct.NiUgKgSy = product.NiUgKgSy;
            existingProduct.CuMgKg = product.CuMgKg;
            existingProduct.CuMgKgSy = product.CuMgKgSy;
            existingProduct.ZnMgKg = product.ZnMgKg;
            existingProduct.ZnMgKgSy = product.ZnMgKgSy;
            existingProduct.AsMgKg = product.AsMgKg;
            existingProduct.AsMgKgSy = product.AsMgKgSy;
            existingProduct.SeUgKg = product.SeUgKg;
            existingProduct.SeUgKgSy = product.SeUgKgSy;
            existingProduct.CdUgKg = product.CdUgKg;
            existingProduct.CdUgKgSy = product.CdUgKgSy;
            existingProduct.HgUgKg = product.HgUgKg;
            existingProduct.HgUgKgSy = product.HgUgKgSy;
            existingProduct.PbUgKg = product.PbUgKg;
            existingProduct.PbUgKgSy = product.PbUgKgSy;
            existingProduct.SafetyScore = product.SafetyScore;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}