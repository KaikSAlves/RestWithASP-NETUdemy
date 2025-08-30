using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestWithASP_NETUdemy.Model.Base;

namespace RestWithASP_NETUdemy.Data.VO;

public class PersonVO
{
    
    [JsonPropertyName("code")]
    public long Id { get; set; }
    
    [JsonPropertyName("name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    
    [JsonIgnore]
    public string Address { get; set; }
    
    [JsonPropertyName("sex")]
    public string Gender {get; set;}
    
}