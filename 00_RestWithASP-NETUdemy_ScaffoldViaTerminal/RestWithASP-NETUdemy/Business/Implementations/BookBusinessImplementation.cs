using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository;

namespace RestWithASP_NETUdemy.Business.Implementations;

public class BookBusinessImplementation : IBookBusiness
{

    private readonly IBookRepository _bookRepository;

    public BookBusinessImplementation(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    
    public Book Create(Book t)
    {
       return _bookRepository.Create(t);
    }

    public List<Book> FindAll()
    {
        return _bookRepository.FindAll();
    }

    public Book FindById(long id)
    {
        return _bookRepository.FindById(id);

    }

    public Book Update(Book t)
    {
        return _bookRepository.Update(t);
    }

    public void Delete(long id)
    {
        _bookRepository.Delete(id);
    }
}