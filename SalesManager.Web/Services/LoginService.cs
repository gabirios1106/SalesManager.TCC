using DataTransferObjects.Clients;
using DataTransferObjects.Utils;
using MudBlazor;
using SalesManager.Web.Interfaces;
using System.Text;
using System.Text.Json;

namespace SalesManager.Web.Services
{
    public class LoginService : ILoginService
    {
        private readonly ISnackbar SnackbarService;

        public LoginService(ISnackbar snackbarService)
        {
            SnackbarService = snackbarService;
        }
        
        public async Task<string> LoginAsync(LoginFormPostDTO loginFormPostDTO)
        {
            try
            {
                var loginAsJSon = JsonSerializer.Serialize(loginFormPostDTO);
                HttpResponseMessage httpResponse = await Program.HttpClient.PostAsync("v1/Access/Login", new StringContent(loginAsJSon, Encoding.UTF8, "application/json"));
                string responseContent = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode)
                {
                    return responseContent;
                }
                else
                {
                    SnackbarService.Add(responseContent, Severity.Error);
                    return string.Empty;
                }
            }
            catch (Exception e)
            {
                SnackbarService.Add($"Houve um erro ao acessar a API - {e.Message}", Severity.Error);
                return string.Empty;
            }
        }
    }
}
