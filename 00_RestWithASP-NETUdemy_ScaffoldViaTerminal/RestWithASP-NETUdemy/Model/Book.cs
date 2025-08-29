using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NETUdemy.Model;

[Table("books")]
public class Book
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("author")]
    public string Author { get; set; }
    
    [Column("launch_date")]
    public DateTime LaunchDate { get; set; }
    
    [Column("price")]
    public double price { get; set; }
    
    [Column("title")]
    public string Title { get; set; }

    public Book(long id, string author, DateTime launchDate, double price, string title)
    {
        Id = id;
        Author = author;
        LaunchDate = launchDate;
        this.price = price;
        Title = title;
    }

    public Book()
    {
    }
}