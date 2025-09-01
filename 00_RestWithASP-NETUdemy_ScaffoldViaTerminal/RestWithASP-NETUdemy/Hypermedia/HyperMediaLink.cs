using System.Text;

namespace RestWithASP_NETUdemy.Hypermedia;

public class HyperMediaLink
{
    public string Rel { get; set; }
    public string Href {
        get
        {
            object _lock = new Object();
            lock (_lock)
            {
                StringBuilder sb = new StringBuilder(href);
                return sb.Replace("2%F", "/").ToString();
            }
        }
        set
        {
            href = value;
        }
    }
    private string href;
    public string Action { get; set; }
    public string Type { get; set; }
}