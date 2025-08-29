using RestWithASP_NETUdemy.Business;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository;

namespace RestWithASP_NETUdemy.Business.Implementations;

public class PersonBusinessImplementation : IPersonBusiness
{
    private readonly IPersonRepository _repository;

    public PersonBusinessImplementation(IPersonRepository repository)
    {
        _repository = repository;
    }
    
    //create
    public Person Create(Person person)
    {
        return _repository.Create(person);
    }
    
    //read

    public Person FindById(long id)
    {
        return _repository.FindById(id);
    }
    
    public List<Person> FindAll()
    {
        return _repository.FindAll();
    }

    
    //update
    public Person Update(Person person)
    {
        return  _repository.Update(person);
    }

   

    //delete
    public void Delete(long id)
    {
       _repository.Delete(id);
        
    }
}