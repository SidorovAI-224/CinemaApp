using CinemaApp.BL.DTOs.UserDTOs.User;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task AddUserAsync(UserCreateDto userCreateDto);
        Task UpdateUserAsync(int id, UserUpdateDto userUpdateDto);
        Task DeleteUserByIdAsync(int id);
    }
}