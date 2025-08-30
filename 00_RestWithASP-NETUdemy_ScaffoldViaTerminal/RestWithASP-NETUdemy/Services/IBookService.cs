using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Repository;

namespace RestWithASP_NETUdemy.Services;

public interface IBookService
{
    BookVO Create(BookVO t);
    List<BookVO> FindAll();
    BookVO FindById(long id);
    BookVO Update(BookVO t);
    void Delete(long id);
}