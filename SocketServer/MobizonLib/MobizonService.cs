using System.Net;
using Newtonsoft.Json;

namespace MobizonLib;

public class MobizonService
{
    private string _apiKey;
    private readonly HttpClient _httpClient;

    public MobizonService(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task<MobizonDTO<BalanceDTO>?> getBalance()
    {
        string urlBalance = $"http://api.mobizon.ua/service/user/getownbalance?apiKey={_apiKey}";
        WebRequest request = WebRequest.Create(urlBalance);
        request.ContentType = "application/json";
        request.Method = "GET";
        try
        {

            using (WebResponse response = request.GetResponse())
            {
                // Get the stream containing content returned by the server
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content
                        string responseFromServer = reader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<MobizonDTO<BalanceDTO>>(responseFromServer);
                        return result;
                    }
                }
            }
        }
        catch (WebException e)
        {
            Console.WriteLine("WebException occurred: {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception occurred: {0}", e.Message);
        }
        return null;
    }

    public async Task<MobizonDTO<SMSDTO>> sendSMS(string phone, string text)
    {
        string urlBalance = $"http://api.mobizon.ua/service/message/sendsmsmessage?apiKey={_apiKey}&recipient={phone}&text={Uri.EscapeDataString(text)}";
        WebRequest request = WebRequest.Create(urlBalance);
        request.ContentType = "application/json";
        request.Method = "GET";
        try
        {

            using (WebResponse response = request.GetResponse())
            {
                // Get the stream containing content returned by the server
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content
                        string responseFromServer = reader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<MobizonDTO<SMSDTO>>(responseFromServer);
                        return result;
                    }
                }
            }
        }
        catch (WebException e)
        {
            Console.WriteLine("WebException occurred: {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception occurred: {0}", e.Message);
        }
        return null;
    }

}
