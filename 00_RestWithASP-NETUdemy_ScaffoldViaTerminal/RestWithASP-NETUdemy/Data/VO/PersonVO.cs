using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestWithASP_NETUdemy.Hypermedia;
using RestWithASP_NETUdemy.Hypermedia.Abstract;
using RestWithASP_NETUdemy.Model.Base;

namespace RestWithASP_NETUdemy.Data.VO;

public class PersonVO : ISupportHyperMedia
{
    
    public long Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Address { get; set; }
    
    public string Gender {get; set;}

    public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
}