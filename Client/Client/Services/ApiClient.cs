using System.Configuration;
using System.Text.Json;
using SharedLibrary.Models;

namespace Client.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiClient()
        {
            var baseAddress = ConfigurationManager.AppSettings["ApiBaseAddress"];
            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                MessageBox.Show($"API base address is not configured.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw new InvalidOperationException("API base address is not configured.");
            }
            _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Obsługa nierozróżniania wielkości liter
            };
        }

        public async Task<List<TableInfo>> GetTablesAsync()
        {
            return await GetAsync<List<TableInfo>>("Database/tables");
        }

        public async Task<List<TableInfo>> GetViewsAsync()
        {
            return await GetAsync<List<TableInfo>>("Database/views");
        }

        public async Task<List<ColumnInfo>> GetColumnsAsync(string tableName)
        {
            return await GetAsync<List<ColumnInfo>>($"Database/columns/{tableName}");
        }

        private async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);

                response.EnsureSuccessStatusCode(); // Sprawdzanie, czy status HTTP jest pomyślny

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(json, _jsonOptions)
                       ?? throw new InvalidOperationException("Deserialization returned null.");
            }
            catch (HttpRequestException ex)
            {
                // Obsługa błędów związanych z HTTP
                throw new Exception($"Error fetching data from API: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                // Obsługa błędów serializacji JSON
                throw new Exception($"Error deserializing response: {ex.Message}", ex);
            }
        }
    }
}
