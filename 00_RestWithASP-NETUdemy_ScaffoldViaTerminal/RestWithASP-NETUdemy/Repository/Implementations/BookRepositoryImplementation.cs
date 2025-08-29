using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;

namespace RestWithASP_NETUdemy.Repository.Implementations;

public class BookRepositoryImplementation : IBookRepository
{

    private MySqlContext _context;

    public BookRepositoryImplementation(MySqlContext context)
    {
        _context = context;
    }
    public Book Create(Book t)
    {
        try
        {
            _context.Books.Add(t);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }

        return t;
    }

    public List<Book> FindAll()
    {
        return _context.Books.ToList();
    }

    public Book FindById(long id)
    {
        return _context.Books.SingleOrDefault(x => x.Id.Equals(id));
    }

    public Book Update(Book t)
    {
        if (!Exists(t.Id)) return null;

        var result = _context.Books.SingleOrDefault(x => x.Id.Equals(t.Id));

        if (result != null)
        {
            try
            {
                _context.Entry(result).CurrentValues.SetValues(t);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        return t;
    }

    public void Delete(long id)
    {
        var result = _context.Books.SingleOrDefault(x => x.Id.Equals(id));

        if (result != null)
        {
            try
            {
                _context.Books.Remove(result);
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
        return _context.Books.Any(x => x.Id.Equals(id));
    }
}