﻿using RESTWithASP_NET.Configurations;
using RESTWithASP_NET.Data.VO;
using RESTWithASP_NET.Repository;
using RESTWithASP_NET.Services;
using RESTWithASP_NET.Services.Implementations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RESTWithASP_NET.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);
            if (user == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.user_name)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.refresh_token = refreshToken;
            user.refresh_token_expiry_time = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = _repository.ValidateCredentials(username);

            if (user == null ||
                user.refresh_token != refreshToken || 
                user.refresh_token_expiry_time <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.refresh_token = refreshToken;

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public bool RevokeToken(string username)
        {
            return _repository.RevokeToken(username);
        }
    }
}
