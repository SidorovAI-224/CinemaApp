using CinemaApp.BL.DTOs.UserDTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
