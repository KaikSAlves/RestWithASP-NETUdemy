using RestWithASP_NETUdemy.Data.Converter.Contract;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Data.Converter.Implementations;

public class BookConverter : IParse<BookVO, Book>, IParse<Book, BookVO>
{
    public Book Parse(BookVO origin)
    {
        if (origin == null) return null;

        return new Book
        {
            Id = origin.Id,
            Title = origin.Title,
            Author = origin.Author,
            LaunchDate = origin.LaunchDate,
            Price = origin.Price
        };
    }


    public BookVO Parse(Book origin)
    {
        if (origin == null) return null;

        return new BookVO
        {
            Id = origin.Id,
            Title = origin.Title,
            Author = origin.Author,
            LaunchDate = origin.LaunchDate,
            Price = origin.Price
        };
    }

    public List<Book> Parse(List<BookVO> origin)
    {
        if (origin == null) return null;
        return origin.Select(item => Parse(item)).ToList();
    }

    public List<BookVO> Parse(List<Book> origin)
    {
        if (origin == null) return null;
        return origin.Select(item => Parse(item)).ToList();
    }
}