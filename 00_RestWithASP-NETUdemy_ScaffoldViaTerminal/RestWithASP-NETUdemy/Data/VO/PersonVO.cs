using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestWithASP_NETUdemy.Model.Base;

namespace RestWithASP_NETUdemy.Data.VO;

public class PersonVO
{
    
    public long Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }
    
    public string Gender {get; set;}
    
}