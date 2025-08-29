using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Repository;

public interface IBookRepository
{
    Book Create(Book t);
    List<Book> FindAll();
    Book FindById(long id);
    Book Update(Book t);
    void Delete(long id);
    bool Exists(long id);
}