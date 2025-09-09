using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository.Generic;

namespace RestWithASP_NETUdemy.Repository;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(MySqlContext context) : base(context)
    {
    }

    public Person Disable(long id)
    {
        if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;

        var user = _context.Persons.FirstOrDefault(p => p.Id.Equals(id));

        if (user != null)
        {
            user.Enable = false;

            try
            {
                _context.Entry(user).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        return user;
    }

    public Person Enable(long id)
    {
        if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;

        var user = _context.Persons.FirstOrDefault(p => p.Id.Equals(id));

        if (user != null)
        {
            user.Enable = true;

            try
            {
                _context.Entry(user).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        return user;
    }
}