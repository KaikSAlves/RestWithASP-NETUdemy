using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository;
using RestWithASP_NETUdemy.Repository.Generic;

namespace RestWithASP_NETUdemy.Services.Implementations;

public class BookServiceImplementation : IBookService
{

    private readonly IRepository<Book> _repository;

    public BookServiceImplementation(IRepository<Book> repository)
    {
        _repository = repository;
    }
    
    
    public Book Create(Book t)
    {
       return _repository.Create(t);
    }

    public List<Book> FindAll()
    {
        return _repository.FindAll();
    }

    public Book FindById(long id)
    {
        return _repository.FindById(id);

    }

    public Book Update(Book t)
    {
        return _repository.Update(t);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}