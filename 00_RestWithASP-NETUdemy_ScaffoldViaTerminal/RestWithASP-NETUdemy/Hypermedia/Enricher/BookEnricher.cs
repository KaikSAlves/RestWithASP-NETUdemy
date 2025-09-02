using System.Text;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Hypermedia.Constants;
using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Hypermedia.Enricher;

public class BookEnricher : ContentResponseEnricher<BookVO>
{
    
    private readonly object _lock = new object();
    
    protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
    {
        var path = "api/book/v1";
        string link = GetLink(content.Id, urlHelper, path);
        
        System.Console.WriteLine(link);
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerb.GET,
            Href = link,
            Rel = RelationTye.self,
            Type = ResponseTypeFormat.DefaultGet
        });
        
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerb.POST,
            Href = link,
            Rel = RelationTye.self,
            Type = ResponseTypeFormat.DefaultPost
        });
        
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerb.PUT,
            Href = link,
            Rel = RelationTye.self,
            Type = ResponseTypeFormat.DefaultPut
        });
        
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerb.PATCH,
            Href = link,
            Rel = RelationTye.self,
            Type = ResponseTypeFormat.DefaultPatch
        });
        
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerb.DELETE,
            Href = link,
            Rel = RelationTye.self,
            Type = "int"
        });

        return null;    
    }

    private string GetLink(long id, IUrlHelper urlHelper, string path)
    {
        lock (_lock)
        {
            var request = urlHelper.ActionContext.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host.Value}";
            var link = $"{baseUrl}/{path}/{id}";
            
            return new StringBuilder(link).Replace("%2f", "/").ToString();
        }
    }
}   