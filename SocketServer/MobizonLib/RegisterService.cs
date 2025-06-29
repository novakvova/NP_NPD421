using Newtonsoft.Json;

namespace MobizonLib;

interface IRegisterService
{
    Task<bool> RegisterUser(User user);
}

public class RegisterService : IRegisterService
{
    private readonly HttpClient _httpClient;

    public RegisterService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://npd421.itstep.click/");
    }

    public async Task<bool> RegisterUser(User user)
    {
        string requestUri = "api/account/register";
        var json = JsonConvert.SerializeObject(user);
        var content = new StringContent(json, System.Text.Encoding.UTF8,
            "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync(requestUri, content);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else if ((int)response.StatusCode == 400)
        {
            var responseErrors = await response.Content.ReadAsStringAsync();

            var registerResponse = JsonConvert.DeserializeObject<RegisterResponse>(responseErrors) ?? new RegisterResponse();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            PrintErrors("Email", registerResponse.Errors.Email.ToArray());
            PrintErrors("FirstName", registerResponse.Errors.FirstName.ToArray());
            PrintErrors("SecondName", registerResponse.Errors.SecondName.ToArray());
            PrintErrors("Photo", registerResponse.Errors.Photo.ToArray());
            PrintErrors("Phone", registerResponse.Errors.Phone.ToArray());
            PrintErrors("Password", registerResponse.Errors.Password.ToArray());
            PrintErrors("ConfirmPassword", registerResponse.Errors.ConfirmPassword.ToArray());
            Console.ResetColor();

            return false;
        }
        else
        {
            Console.WriteLine($"Error register: {response.StatusCode}");
            return false;
        }
    }

    static void PrintErrors(string field, string[] messages)
    {
        if (messages != null && messages.Length > 0)
        {
            foreach (var msg in messages)
            {
                Console.WriteLine($" - {field}: {msg}");
            }
        }
    }

}
