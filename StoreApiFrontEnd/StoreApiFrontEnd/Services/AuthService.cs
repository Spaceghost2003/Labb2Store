using StoreApiFrontEnd.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace StoreApiFrontEnd.Services
{
    public class AuthService : IAuthService
    {
      
        private bool _isLoggedIn = false;
        private string? _currentUser;
        private string? _token;
        private readonly HttpClient _httpClient;

        public bool IsLoggedIn => _isLoggedIn;
        public string? CurrentUser => _currentUser;
        public string? Token => _token;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> LoginAsync(string email)
        {
            try
            {
                var loginRequest = new { Email = email };
                var response = await _httpClient.PostAsJsonAsync("api/login", loginRequest);

                Console.WriteLine($"Response Status: {response.StatusCode}");
                Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                    if (!string.IsNullOrEmpty(result?.Token))
                    {
                        _isLoggedIn = true;
                        _currentUser = email;
                        _token = result.Token;

                        return true;
                    }
                }
                return false;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Login failed: {ex.Message}");
                return false;
            }
        }

        public Task LogoutAsync()
        {
            _isLoggedIn = false;
            _currentUser = null;
            _token = null;
            return Task.CompletedTask;
        }

        public class TokenResponse
        {
            public string Token { get; set; }
        }
    }
}
