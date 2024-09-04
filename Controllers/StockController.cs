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

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            
            _context.Stocks.Add(stockModel); // Entity Framework start tracking it
            _context.SaveChanges(); // and here it really saves into DB
            
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if (stockModel == null)
            {
                return NotFound();
            }
            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName; 
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;
            
            _context.SaveChanges();
            return Ok(stockModel.ToStockDto());
        }
    }
}