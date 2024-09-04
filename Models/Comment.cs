using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StocksDotnetProj.Models;

[Table("comments")]
public class Comment
{ 
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public int? StockId { get; set; } // this is the fk that connects
    
    public Stock? Stock { get; set; } // navigation property, it allows us to navigate into Stock model
}