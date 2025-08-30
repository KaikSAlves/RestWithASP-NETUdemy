using RestWithASP_NETUdemy.Data.Converter.Implementations;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository;
using RestWithASP_NETUdemy.Repository.Generic;

namespace RestWithASP_NETUdemy.Services.Implementations;

public class BookServiceImplementation : IBookService
{
    private readonly IRepository<Book> _repository;
    private readonly BookConverter _converter;

    public BookServiceImplementation(IRepository<Book> repository)
    {
        _repository = repository;
        _converter = new BookConverter();
    }

    public BookVO Create(BookVO item)
    {
        var bookEntity = _converter.Parse(item);
        return _converter.Parse(_repository.Create(bookEntity));
    }

    public List<BookVO> FindAll()
    {
        return _converter.Parse(_repository.FindAll());
    }

    public BookVO FindById(long id)
    {
        return _converter.Parse(_repository.FindById(id));
    }

    public BookVO Update(BookVO item)
    {
        var bookEntity = _converter.Parse(item);
        return _converter.Parse(_repository.Update(bookEntity));
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}