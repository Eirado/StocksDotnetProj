using StocksDotnetProj.DTOs.Stocks;
using StocksDotnetProj.Models;

namespace StocksDotnetProj.Mappers;

public static class StockMappers // this is a extension class with its extension methods, so it is available everywhere
{
    public static StockDto ToStockDto(this Stock stockModel) 
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap,
        };
    }
}