namespace _3_HttpClient;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string UrlSlug { get; set; } = string.Empty;
    public int Priority { get; set; }
    public string Image { get; set; } = string.Empty;
    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, UrlSlug: {UrlSlug}, Priority: {Priority}, Image: {Image}";
    }


}
