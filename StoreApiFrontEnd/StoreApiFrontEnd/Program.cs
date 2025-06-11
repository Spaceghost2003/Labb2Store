using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using StoreApi.Repositories;
using StoreApi.Repositories.Interfaces;
using StoreApiFrontEnd.Components;
using StoreApiFrontEnd.Services;
using StoreApiFrontEnd.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<JwtAuthHandler>();
builder.Services.AddMudServices();
builder.Services.AddHttpClient("StoreApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7020");
})
.AddHttpMessageHandler<JwtAuthHandler>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IProductService, ProductService>();
/*builder.Services.AddScoped<IAuthService, AuthService>();*/
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService>(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient("StoreApi");
    return new AuthService(client);
});
builder.Services.AddScoped<IUserService>(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient("StoreApi");
    return new UserService(client);
});


var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
