
using RestWithASP_NETUdemy.Data.Converter.Implementations;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Hypermedia.utils;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository;
using RestWithASP_NETUdemy.Repository.Generic;

namespace RestWithASP_NETUdemy.Services.Implementations;

public class PersonServiceImplementation : IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly PersonConverter _converter;

    public PersonServiceImplementation(IPersonRepository repository)
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

    public List<PersonVO> FindByName(string firstName, string lastName)
    {
        return _converter.Parse(_repository.FindByName(firstName, lastName));
    }
    
    public List<PersonVO> FindAll()
    {
        return _converter.Parse(_repository.FindAll());
    }

    public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
    {

        var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
        var size = (pageSize < 0) ? 10 : pageSize;
        var offset = page > 0 ? (page - 1) * size : 0;

        string query = @"SELECT * FROM person p where 1 = 1";
        if (!string.IsNullOrWhiteSpace(name)) query += $" AND p.first_name like '%{name}%' ";
        query += $" ORDER BY p.first_name {sort} limit {size} offset {offset}";

        string countQuery = @"SELECT count(*) FROM person p where 1 = 1";
        if (!string.IsNullOrWhiteSpace(name)) countQuery += $" AND p.first_name like '%{name}%' ";

        var persons = _repository.FindWithPagedSearch(query);
        int totalResults = _repository.GetCount(countQuery);

        return new PagedSearchVO<PersonVO>
        {
            CurrentPage = page,
            List = _converter.Parse(persons),
            PageSize = size,
            SortDirections = sort,
            TotalResults = totalResults
        };
}

    public PersonVO Disable(long id)
    {
        var personEntity = _repository.Disable(id);
        return _converter.Parse(personEntity);
    }
    
    public PersonVO Enable(long id)
    {
        var personEntity = _repository.Enable(id);
        return _converter.Parse(personEntity);
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