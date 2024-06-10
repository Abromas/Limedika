using Limedika.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Limedika.Services;

public class PostCodeService : IPostCodeService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "postit.lt-examplekey";
    private const string BaseUrl = "https://api.postit.lt";

    public PostCodeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> GetPostCodeAsync(string address)
    {
        try
        {
            var formattedAddress = address.Replace(" ", "+").Replace(",", "+");
            var requestUrl = $"{BaseUrl}/?term={formattedAddress}&key={ApiKey}";

            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseContent);

            if (apiResponse != null && apiResponse.Success && apiResponse.Data?.Count > 0)
            {
                return apiResponse.Data[0].PostCode;
            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            Console.WriteLine($"Error fetching postcode: {ex.Message}");
        }

        return null;
    }

    private class ApiResponse
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("message_code")]
        public int MessageCode { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("data")]
        public List<PostCodeData>? Data { get; set; }
    }

    private class PostCodeData
    {
        [JsonPropertyName("post_code")]
        public string? PostCode { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("street")]
        public string? Street { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }

        [JsonPropertyName("only_number")]
        public string? OnlyNumber { get; set; }

        [JsonPropertyName("housing")]
        public string? Housing { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("eldership")]
        public string? Eldership { get; set; }

        [JsonPropertyName("municipality")]
        public string? Municipality { get; set; }

        [JsonPropertyName("post")]
        public string? Post { get; set; }

        [JsonPropertyName("mailbox")]
        public string? Mailbox { get; set; }
    }
}
