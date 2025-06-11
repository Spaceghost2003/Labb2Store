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
        public event Action? OnUserChanged;

        public bool IsLoggedIn => _isLoggedIn;
        public string? CurrentUser
        {
            get => _currentUser;
            private set
            {
                _currentUser = value;
                OnUserChanged?.Invoke(); // Notify listeners
            }
        }

        public string? Token => _token;
        
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> LoginAsync(string email)
        {
            try
            {
                var loginRequest = new { Email = email };
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7020/api/login", loginRequest);

                Console.WriteLine($"Response Status: {response.StatusCode}");
                Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");

                if (response == null)
                {

                }

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                    if (!string.IsNullOrEmpty(result?.Token))
                    {
                        _isLoggedIn = true;
                        _currentUser = email;
                        _token = result.Token;
                        OnUserChanged?.Invoke();
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
