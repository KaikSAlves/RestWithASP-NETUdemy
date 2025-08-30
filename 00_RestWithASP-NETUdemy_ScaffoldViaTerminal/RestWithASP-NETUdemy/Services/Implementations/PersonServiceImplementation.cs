
using RestWithASP_NETUdemy.Data.Converter.Implementations;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository;
using RestWithASP_NETUdemy.Repository.Generic;

namespace RestWithASP_NETUdemy.Services.Implementations;

public class PersonServiceImplementation : IPersonService
{
    private readonly IRepository<Person> _repository;
    private readonly PersonConverter _converter;

    public PersonServiceImplementation(IRepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverter();
    }
    
    //create
    public PersonVO Create(PersonVO person)
    {
        var personEntity = _converter.Parse(person);
        return _converter.Parse(_repository.Create(personEntity));
    }
    
    //read

    public PersonVO FindById(long id)
    {
        return _converter.Parse(_repository.FindById(id));
    }
    
    public List<PersonVO> FindAll()
    {
        return _converter.Parse(_repository.FindAll());
    }

    
    //update
    public PersonVO Update(PersonVO person)
    {
        var personEntity = _converter.Parse(person);
        return  _converter.Parse(_repository.Update(personEntity));
    }

   

    //delete
    public void Delete(long id)
    {
       _repository.Delete(id);
        
    }
}