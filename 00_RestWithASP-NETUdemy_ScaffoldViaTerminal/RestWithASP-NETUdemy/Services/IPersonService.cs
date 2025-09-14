using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Hypermedia.utils;

namespace RestWithASP_NETUdemy.Services;

public interface IPersonService
{
    PersonVO Create(PersonVO person);
    PersonVO FindById(long id);
    PersonVO Update(PersonVO person);
    void Delete(long id);
    List<PersonVO> FindAll();

    PagedSearchVO<PersonVO> FindWithPagedSearch
        (string name, string sortDirection, int pageSize, int page);
    PersonVO Disable(long id);
    
    PersonVO Enable(long id);
    
    List<PersonVO> FindByName(string firstName, string lastName);
}