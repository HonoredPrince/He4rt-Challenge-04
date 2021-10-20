using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services;
using AutoMapper;
using System.Text;
using Api.Domain.DTOs.User;
using Api.Domain.Models;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var listEntity = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(listEntity);
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            return _mapper.Map<UserDTO>(await _repository.FindByIdAsync(id));
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            return _mapper.Map<UserDTO>(await _repository.FindByEmail(email));
        }

        public async Task<UserCreateResultDTO> Create(UserCreateDTO user)
        {
            string userHashedPassword = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            user.Password = userHashedPassword;

            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);

            return _mapper.Map<UserCreateResultDTO>(await _repository.CreateAsync(entity));
        }

        public async Task<UserUpdateResultDTO> Update(UserUpdateDTO user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);

            return _mapper.Map<UserUpdateResultDTO>(await _repository.UpdateAsync(entity));
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider hashAlgorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = hashAlgorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
