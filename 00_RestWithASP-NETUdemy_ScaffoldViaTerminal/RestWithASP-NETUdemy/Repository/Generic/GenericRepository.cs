using Microsoft.EntityFrameworkCore;
using RestWithASP_NETUdemy.Model.Base;
using RestWithASP_NETUdemy.Model.Context;

namespace RestWithASP_NETUdemy.Repository.Generic;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private MySqlContext _context;
    
    private DbSet<T> dataset;

    public GenericRepository(MySqlContext context)
    {
        _context = context;
        dataset = _context.Set<T>();
    }
    
    public T Create(T item)
    {
        try
        {
            dataset.Add(item);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }

        return item;
    }

    public List<T> FindAll()
    {
        return dataset.ToList();
    }

    public T FindById(long id)
    {
        return dataset.SingleOrDefault(x => x.Id.Equals(id));
    }

    public T Update(T item)
    {
        if (!Exists(item.Id)) return null;

        var result = dataset.SingleOrDefault(x => x.Id.Equals(item.Id));

        if (result != null)
        {
            try
            {
                dataset.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        else
        {
            return null;
        }

        return item;
    }

    public void Delete(long id)
    {
        var result = dataset.SingleOrDefault(p => p.Id.Equals(id));

        if (result != null)
        {
            try
            {
                dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

    public bool Exists(long id)
    {
        return dataset.Any(p => p.Id.Equals(id));
    }
}