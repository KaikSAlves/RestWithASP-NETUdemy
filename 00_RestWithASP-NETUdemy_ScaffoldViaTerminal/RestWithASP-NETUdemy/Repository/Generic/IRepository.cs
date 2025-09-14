using RestWithASP_NETUdemy.Model.Base;

namespace RestWithASP_NETUdemy.Repository.Generic;

//obrigado o tipo t ser uma classe que extende de BaseEntity
public interface IRepository<T> where T : BaseEntity
{
    T Create(T item);
    List<T> FindAll();
    T FindById(long id);
    T Update(T item);
    void Delete(long id);
    bool Exists(long id);
    List<T> FindWithPagedSearch(string query);

    int GetCount(string query);
}