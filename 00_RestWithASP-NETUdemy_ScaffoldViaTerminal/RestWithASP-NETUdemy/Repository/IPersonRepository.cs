using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Repository;

public interface IPersonRepository
{
    Person Create(Person t);
    List<Person> FindAll();
    Person FindById(long id);
    Person Update(Person t);
    void Delete(long id);
    bool Exists(long id);
}