using DataTransferObjects.Utils;

namespace SalesManager.API.Interfaces
{
    public interface IUserService
    {
        Task<bool> CheckAccess(LoginFormPostDTO loginFormGetDTO);
    }
}
