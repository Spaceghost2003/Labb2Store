using StoreApi.Models;

namespace StoreApiFrontEnd.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email);
        Task LogoutAsync();
        public event Action? OnUserChanged;
        bool IsLoggedIn { get; }
        string? CurrentUser { get; }
    }
}
