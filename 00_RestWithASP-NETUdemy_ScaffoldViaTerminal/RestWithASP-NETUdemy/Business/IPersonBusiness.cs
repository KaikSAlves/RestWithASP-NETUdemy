using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Business;

public interface IPersonBusiness
{
    Person Create(Person person);
    Person FindById(long id);
    Person Update(Person person);
    void Delete(long id);
    List<Person> FindAll();
}