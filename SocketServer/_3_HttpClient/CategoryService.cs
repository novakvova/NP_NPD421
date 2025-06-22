using Newtonsoft.Json;

namespace _3_HttpClient;

interface ICategoryService
{
    // Define methods that the CategoryService should implement
    // For example:
    Task<CategoriesResponse?> GetCategoriesUri(CategorySearch categorySearch);
    Task<bool> DeleteCategoryAsync(int id);
    Task<bool> AddCategoryAsync(CategoryCreate categoryCreate);
    // Task<IEnumerable<Category>> GetCategoriesAsync();
    // Task<Category> GetCategoryByIdAsync(int id);
    // Task AddCategoryAsync(Category category);
    // Task UpdateCategoryAsync(Category category);
    // Task DeleteCategoryAsync(int id);
}

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;
    public CategoryService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://npd421.itstep.click/");
    }
    public async Task<CategoriesResponse?> GetCategoriesUri(CategorySearch categorySearch)
    {
        // Формування URI з параметрами запиту
        string requestUri = $"api/categories/search?page={categorySearch.Page}";
        HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

            // Десеріалізація JSON у об'єкт CategoriesResponse
            var categoriesResponse = JsonConvert.DeserializeObject<CategoriesResponse>(json);

            return categoriesResponse;
        }
        else
        {
            Console.WriteLine($"Помилка: {response.StatusCode}");
            return null;
        }
    }
    public async Task<bool> DeleteCategoryAsync(int id)
    {
        string requestUri = $"api/categories/delete/{id}";
        HttpResponseMessage response = await _httpClient.DeleteAsync(requestUri);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            Console.WriteLine($"Error deleting category: {response.StatusCode}");
            return false;
        }
    }
    public async Task<bool> AddCategoryAsync(CategoryCreate categoryCreate)
    {
        string requestUri = "api/categories/add";
        var json = JsonConvert.SerializeObject(categoryCreate);
        var content = new StringContent(json, System.Text.Encoding.UTF8, 
            "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(requestUri, content);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            Console.WriteLine($"Error adding category: {response.StatusCode}");
            return false;
        }
    }

    // Реалізація інших методів інтерфейсу ICategoryService

}
