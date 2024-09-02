namespace StocksDotnetProj.Models;

public class Comment
{ 
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public int? StockId { get; set; } // this is the fk that connects
    
    public Stock? Stock { get; set; } // navigation property, it allows us to navigate into Stock model
}