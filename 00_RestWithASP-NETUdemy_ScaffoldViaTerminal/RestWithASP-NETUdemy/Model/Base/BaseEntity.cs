using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NETUdemy.Model.Base;

public class BaseEntity
{
    [Column("id")]
    public long Id { get; set; }
}