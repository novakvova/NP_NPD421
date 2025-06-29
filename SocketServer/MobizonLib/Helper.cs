
namespace MobizonLib;

public static class Helper
{
    public static async Task<string?> UriToBase64(this string uri)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            return null;
        }

        HttpClient client = new HttpClient();

        try
        {
            byte[] fileBytes = await client.GetByteArrayAsync(uri);
            return Convert.ToBase64String(fileBytes);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static string? ToPhoneFormat(this string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            return null;
        }

        foreach (var symbol in phone)
        {
            if (symbol <= '0' && symbol >= '9')
            {
                return null;
            }
        }

        if (phone.Length == 10)
        {
            phone = "38" + phone;
        }

        if (phone.Length == 12 && phone.StartsWith("38"))
        {
            return $"+{phone.Substring(0, 2)} ({phone.Substring(2, 3)}) {phone.Substring(5, 3)} {phone.Substring(8, 2)} {phone.Substring(10, 2)}";
        }

        return null;
    }
}
