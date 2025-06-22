namespace _3_HttpClient;

public class CategoriesResponse
{
    public List<Category> Categories { get; set; } = new List<Category>();
    public int Pages { get; set; }
    public int CurrentPage { get; set; }
    public int Total { get; set; }

    public override string ToString()
    {
        return $"Pages: {Pages}, " +
            $"CurrentPage: {CurrentPage}, " +
            $"Total: {Total}, " +
            $"CategoriesCount: {Categories?.Count ?? 0}";
    }
}
