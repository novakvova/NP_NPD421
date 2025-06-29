namespace MobizonLib;

public class UserService
{
    private readonly HttpClient _httpClient;
    public UserService()
    {
        _httpClient = new HttpClient();
    }
    public async Task DeleteRangeUsersAsync(int minId, int maxId)
    {
        for (int userId = minId; userId <= maxId; userId++)
        {

            try
            {
                var requestUri = $"https://npd421.itstep.click/api/Users/delete/{userId}";
                var request = new HttpRequestMessage(HttpMethod.Delete, requestUri);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));

                using var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine("---Error---", ex.Message);
            }
        }
    }
}
