using RestWithASP_NETUdemy.Data.VO;

namespace RestWithASP_NETUdemy.Services;

public interface IPersonService
{
    PersonVO Create(PersonVO person);
    PersonVO FindById(long id);
    PersonVO Update(PersonVO person);
    void Delete(long id);
    List<PersonVO> FindAll();

    PersonVO Disable(long id);
    
    PersonVO Enable(long id);
}