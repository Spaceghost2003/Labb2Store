using StoreApiFrontEnd.Services.Interfaces;
using System.Net.Http.Headers;

public class JwtAuthHandler : DelegatingHandler
{
    private readonly ITokenService _tokenService;

    public JwtAuthHandler(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _tokenService.Token;
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}