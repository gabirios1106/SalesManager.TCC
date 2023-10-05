using DataTransferObjects.Utils;
using Microsoft.EntityFrameworkCore;
using SalesManager.API.Data;
using SalesManager.API.Interfaces;

namespace SalesManager.API.Services
{
    public class UserService : IUserService
    {
        private readonly SalesManagerContext _context;

        public UserService(SalesManagerContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckAccess(LoginFormPostDTO loginFormPostDTO)
        {
            return await _context.User
                                  .AsNoTracking()
                                  .AsSplitQuery()
                                  .AnyAsync(u => u.Email == loginFormPostDTO.Email && u.Password == loginFormPostDTO.Password);
        }
    }
}
