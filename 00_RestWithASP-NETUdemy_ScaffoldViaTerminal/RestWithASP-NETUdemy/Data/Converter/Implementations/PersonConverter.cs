using RestWithASP_NETUdemy.Data.Converter.Contract;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Data.Converter.Implementations;

public class PersonConverter : IParse<PersonVO, Person>, IParse<Person, PersonVO>
{
    public Person Parse(PersonVO origin)
    {
        if (origin == null) return null;

        return new Person
        {
            Id = origin.Id,
            FirstName = origin.FirstName,
            LastName = origin.LastName,
            Address = origin.Address,
            Gender = origin.Gender   
        };
    }


    public PersonVO Parse(Person origin)
    {
        if (origin == null) return null;

        return new PersonVO
        {
            Id = origin.Id,
            FirstName = origin.FirstName,
            LastName = origin.LastName,
            Address = origin.Address,
            Gender = origin.Gender   
        };
    }

    public List<Person> Parse(List<PersonVO> origin)
    {
        if (origin == null) return null;

        return origin.Select(item => Parse(item)).ToList();
    }

    public List<PersonVO> Parse(List<Person> origin)
    {
        if (origin == null) return null;

        return origin.Select(item => Parse(item)).ToList();
    }
}