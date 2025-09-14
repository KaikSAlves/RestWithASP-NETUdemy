using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using RestWithASP_NETUdemy.Hypermedia.Abstract;
using RestWithASP_NETUdemy.Hypermedia.utils;

namespace RestWithASP_NETUdemy.Hypermedia;

public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISupportHyperMedia
{

    public ContentResponseEnricher()
    {
        
    }
    public bool CanEnrich(Type contextType)
    {
        return contextType == typeof(T) || contextType == typeof(List<T>) ||  contextType == typeof(PagedSearchVO<T>);;
    }

    protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);

    public bool CanEnrich(ResultExecutingContext response)
    {
        if (response.Result is OkObjectResult okObjectResult)
        {
            return CanEnrich(okObjectResult.Value.GetType());
        }

        return false;
    }

    public async Task Enrich(ResultExecutingContext response)
    {
        var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
        if (response.Result is OkObjectResult okObjectResult)
        {
            if (okObjectResult.Value is T model)
            {
                await EnrichModel(model, urlHelper);
            }
            else if (okObjectResult.Value is List<T> collection)
            {
                ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                Parallel.ForEach(bag, (element) => { EnrichModel(element, urlHelper); });
            }
            else if (okObjectResult.Value is PagedSearchVO<T> pagedSearch)
            {
                Parallel.ForEach(pagedSearch.List.ToList(), (element) => { EnrichModel(element, urlHelper); });
            }
        }

        await Task.FromResult<object>(null);
        

    }
}
