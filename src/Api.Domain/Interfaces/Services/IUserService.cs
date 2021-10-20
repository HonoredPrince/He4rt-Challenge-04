using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(Guid id);
        Task<UserDTO> GetByEmail(string email);
        Task<UserCreateResultDTO> Create(UserCreateDTO user);
        Task<UserUpdateResultDTO> Update(UserUpdateDTO user);
        Task<bool> Delete(Guid id);
    }
}
