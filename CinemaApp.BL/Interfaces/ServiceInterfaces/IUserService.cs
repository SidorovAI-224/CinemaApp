using CinemaApp.BL.DTOs.UserDTOs.User;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(UserCreateDTO userCreateDTO);
        Task UpdateUserAsync(int id, UserUpdateDTO userUpdateDTO);
        Task DeleteUserByIdAsync(int id);
    }
}