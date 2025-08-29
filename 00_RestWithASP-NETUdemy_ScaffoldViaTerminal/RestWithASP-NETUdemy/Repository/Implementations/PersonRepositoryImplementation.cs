using RestWithASP_NETUdemy.Business;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;

namespace RestWithASP_NETUdemy.Repository.Implementations;

public class PersonRepositoryImplementation : IPersonRepository
{
    private MySqlContext _context;

    public PersonRepositoryImplementation(MySqlContext context)
    {
        _context = context;
    }
    
    //create
    public Person Create(Person person)
    {
        try
        {
            _context.Add(person);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }
        
        return person;
    }
    
    //read

    public Person FindById(long id)
    {
        return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
    }
    
    public List<Person> FindAll()
    {
        return _context.Persons.ToList();
    }

    //update
    public Person Update(Person person)
    {
        if(!Exists(person.Id)) return new  Person();
        
        var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

        if (result != null)
        {
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        return person;
    }

   

    //delete
    public void Delete(long id)
    {
        var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

        if (result != null)
        {
            try
            {
                _context.Persons.Remove(result);
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
        return _context.Persons.Any(p => p.Id.Equals(id));
    }
}