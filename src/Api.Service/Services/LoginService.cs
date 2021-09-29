using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Domain.DTOs.Token;
using Api.Domain.DTOs.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.Auth;
using Api.Domain.Security;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        private readonly IUserRepository _repository;
        private TokenConfiguration _configuration;
        private ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginService(IUserRepository repository,
                            TokenConfiguration configuration,
                            ITokenService tokenService,
                            IMapper mapper)
        {
            _repository = repository;
            _configuration = configuration;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<TokenDTO> ValidateCredentials(UserLoginDTO userCredentials)
        {
            var userEntity = _mapper.Map<UserEntity>(userCredentials);
            var user = await _repository.ValidateCredentials(userEntity);

            if (user == null)
                return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userCredentials.Email)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireTime = DateTime.Now.AddDays(_configuration.DaysToExpire);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            await _repository.RefreshUserInfo(user);

            return new TokenDTO
            {
                Authenticated = true,
                CreateDate = createDate.ToString(DATE_FORMAT),
                ExpirationDate = expirationDate.ToString(DATE_FORMAT),
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<TokenDTO> ValidateCredentials(TokenDTO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var email = principal.Identity.Name;

            var user = await _repository.ValidateCredentials(email);

            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpireTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            await _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO
            {
                Authenticated = true,
                CreateDate = createDate.ToString(DATE_FORMAT),
                ExpirationDate = expirationDate.ToString(DATE_FORMAT),
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<bool> RevokeToken(string email)
        {
            return await _repository.RevokeToken(email);
        }
    }
}
