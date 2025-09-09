using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Repository.Generic;

namespace RestWithASP_NETUdemy.Repository;

public interface IPersonRepository : IRepository<Person>
{
    Person Disable(long id);
    
    Person Enable(long id);
    
    List<Person> FindByName(string firstName, string lastName);
}