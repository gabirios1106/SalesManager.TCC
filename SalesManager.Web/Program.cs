using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using SalesManager.Web;
using SalesManager.Web.Authentication;
using SalesManager.Web.Interfaces;
using SalesManager.Web.Services;
using System.Security.Claims;

public class Program
{
    public static HttpClient HttpClient = new();
    private static AuthenticationState s_authenticationState;
    private static int s_idUser;
    private static string s_environment;

    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        HttpClient.BaseAddress = new Uri(GetBaseAddress(builder.HostEnvironment.Environment));
        builder.Services.AddScoped(sp => HttpClient);
        builder.Services.AddAuthorizationCore();

        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
            config.SnackbarConfiguration.PreventDuplicates = true;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 2500;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });

        builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IAPIService, APIService>();
        builder.Services.AddScoped<IRegisterService, RegisterService>();
        builder.Services.AddScoped<IStockMovementService, StockMovementService>();
        builder.Services.AddScoped<IFinancialManagerService, FinancialManagerService>();

        builder.Services.AddScoped<AuthenticationProvider>();
        builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProvider>(
            provider => provider.GetRequiredService<AuthenticationProvider>()
        );

        await builder.Build().RunAsync();
    }

    public static Task<AuthenticationState> GetAuthenticationState()
    {
        return (s_authenticationState is null) ? Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))) : Task.FromResult(s_authenticationState);
    }

    public static void SetAuthenticationState(ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal is null)
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        }

        s_authenticationState = new AuthenticationState(claimsPrincipal);
    }

    public static void SetIdUser(int idUser) => s_idUser = idUser;
    public static int GetIdUser() => s_idUser;

    private static string GetBaseAddress(string environment)
    {
        s_environment = environment;

        return (s_environment == "Production") ? "https://salesmanagertccapi.azurewebsites.net/api/" : "https://localhost:7126/api/";
    }
}