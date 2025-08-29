using RestWithASP_NETUdemy.Business;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository;
using RestWithASP_NETUdemy.Repository.Generic;

namespace RestWithASP_NETUdemy.Business.Implementations;

public class PersonBusinessImplementation : IPersonBusiness
{
    private readonly IRepository<Person> _repository;

    public PersonBusinessImplementation(IRepository<Person> repository)
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