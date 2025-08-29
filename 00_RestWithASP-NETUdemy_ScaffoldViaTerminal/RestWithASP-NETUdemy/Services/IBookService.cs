using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Repository;

namespace RestWithASP_NETUdemy.Services;

public interface IBookService
{
    Book Create(Book t);
    List<Book> FindAll();
    Book FindById(long id);
    Book Update(Book t);
    void Delete(long id);
}