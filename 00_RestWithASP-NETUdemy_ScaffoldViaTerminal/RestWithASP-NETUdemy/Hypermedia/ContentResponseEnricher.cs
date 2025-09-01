using Microsoft.AspNetCore.Mvc.Filters;
using RestWithASP_NETUdemy.Hypermedia.Abstract;

namespace RestWithASP_NETUdemy.Hypermedia;

public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISupportHyperMedia
{
    public bool CanEnrich(ResultExecutingContext context)
    {
        throw new NotImplementedException();
    }

    public Task Enrich(ResultExecutingContext context)
    {
        throw new NotImplementedException();
    }
}