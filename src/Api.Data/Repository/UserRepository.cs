using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(MyContext context) : base(context)
        {

        }

        public async Task<UserEntity> ValidateCredentials(UserEntity user)
        {
            try
            {
                var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
                return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(user.Email) && u.Password.Equals(pass));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<UserEntity> ValidateCredentials(string email)
        {
            try
            {
                return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<UserEntity> RefreshUserInfo(UserEntity user)
        {
            if (!await _dataset.AnyAsync(u => u.Id.Equals(user.Id)))
                return null;

            var result = await _dataset.SingleOrDefaultAsync(u => u.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    await _context.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> RevokeToken(string email)
        {
            var user = await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
            if (user is null)
                return false;
            user.RefreshToken = null;
            await _context.SaveChangesAsync();
            return true;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider hashAlgorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = hashAlgorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            if (!await _dataset.AnyAsync(u => u.Email.Equals(email)))
                return null;
            try
            {
                return await _dataset.SingleOrDefaultAsync(u => u.Email.Equals(email));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
