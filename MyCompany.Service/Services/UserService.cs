using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyCompany.Core.Models.Entities;
using MyCompany.Core.Repositories;
using MyCompany.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        //private readonly IOptions<AppSettings> _appSettings;

        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _unitOfWork.User.Authenticate(username, password);
            if (user == null) return null; // return new UserResponse

            var tokenHandler = new JwtSecurityTokenHandler();
            // method 1
            string secret = _configuration.GetSection("AppSettings").Value;
            //method 2
            //string secret2 = _appSettings.Value.Secret;
            var key = Encoding.ASCII.GetBytes(secret); // encode all strings
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.User.GetAllAsync();
        }
    }

    public interface IConfiguratio
    {
    }
}
