namespace _3_HttpClient;

public class CategoryCreate
{
    public string Title { get; set; } = string.Empty;
    public string UrlSlug { get; set; } = string.Empty;
    public int Priority { get; set; }
    public string Image { get; set; } = string.Empty;
}
