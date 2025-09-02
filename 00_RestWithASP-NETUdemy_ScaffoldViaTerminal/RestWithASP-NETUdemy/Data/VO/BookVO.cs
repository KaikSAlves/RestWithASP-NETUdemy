using RestWithASP_NETUdemy.Hypermedia;
using RestWithASP_NETUdemy.Hypermedia.Abstract;

namespace RestWithASP_NETUdemy.Data.VO;

public class BookVO : ISupportHyperMedia
{
    
    public long Id { get; set; }
    
    public string Author { get; set; }
    
    public DateTime LaunchDate { get; set; }
   
    public double Price { get; set; }
    
    public string Title { get; set; }

    public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
}