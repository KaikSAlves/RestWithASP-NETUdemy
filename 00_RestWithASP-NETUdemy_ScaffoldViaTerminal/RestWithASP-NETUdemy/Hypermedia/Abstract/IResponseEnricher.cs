using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithASP_NETUdemy.Hypermedia.Abstract;

public interface IResponseEnricher
{
    bool CanEnrich(ResultExecutingContext context);
    
    Task Enrich(ResultExecutingContext context);
}