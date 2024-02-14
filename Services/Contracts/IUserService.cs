using System;
using Entities.ModelsDTO;

namespace Services.Abstract
{
	public interface IUserService
	{
        Task CreateUser(UserForRegistrationDto userDto);

        Task DeleteUser(int id);

        Task<List<UserForRegistrationDto>> GetAllUsers();

        Task UpdateUser(UserForRegistrationDto userDto);

        Task<UserForRegistrationDto> GetUserById(int id);
    }
}

