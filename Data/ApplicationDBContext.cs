using Microsoft.EntityFrameworkCore;
using StocksDotnetProj.Models;

namespace StocksDotnetProj.Data;

public class ApplicationDBContext(DbContextOptions dbContextOptions)
    : DbContext(dbContextOptions) // search individual tables 
{
    public DbSet<Stock> Stocks { get; set; }
    
    public DbSet<Comment> Comments { get; set; }
    
    
}