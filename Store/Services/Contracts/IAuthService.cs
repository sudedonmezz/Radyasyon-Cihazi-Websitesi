using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles{get;}
        IEnumerable<IdentityUser> GetAllUsers();

        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);

        Task<IdentityUser> GetOneUser(string userName);

        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName); //rollerle beraber işlem yaptğımız için bu alana ihtiyaç var!!

        Task Update(UserDtoForUpdate userDto);

        Task<IdentityResult> ResetPassword(ResetPasswordDto model);

        Task<IdentityResult> DeleteOneUser(string Email);

    }
}