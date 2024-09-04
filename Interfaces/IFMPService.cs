using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksDotnetProj.Models;

namespace StocksDotnetProj.Interfaces
{
    public interface IFMPService
    {
        Task<Stock> FindStockBySymbolAsync(string symbol);
    }
}