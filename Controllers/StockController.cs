using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StocksDotnetProj.Data;
using StocksDotnetProj.DTOs.Stocks;
using StocksDotnetProj.Mappers;
using StocksDotnetProj.Models;

namespace StocksDotnetProj.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController(ApplicationDBContext context) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;

        [HttpGet]
        public IActionResult GetAll() // the IActionResult it is a wrapper that expects the HTTP returns(OK in this case 200+)
        {
            var stocks = _context.Stocks.ToList()     
                .Select(s => s.ToStockDto()); // defer execution 
            
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }
            
            return Ok(stock.ToStockDto());
        }

    }
}