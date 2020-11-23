using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Infrastructure.Validator;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration Configuration;
        private readonly IRepository<Person> _personRepository;
        public AuthService(IConfiguration configuration, IRepository<Person> personRepository)
        {
            Configuration = configuration;
            _personRepository = personRepository;
        }
        public async Task<string> AuthUserAsync(Login login)
        {
            var validator = new LoginValidator();
            validator.ValidateAndThrow(login);

            var user = await GetPersonData(login);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Discriminator)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task<Person> GetPersonData(Login login)
        {
            Expression<Func<Person, bool>> filter = x => x.IsDeleted == false
                && x.Email.Equals(login.Email) && x.Password.Equals(login.Password);
            var persons = await _personRepository.GetByFilterAsync(filter);
            if (persons.Count < 1)
                throw new Exception("Email or password incorrect");
            return persons.FirstOrDefault();
        }
    }
}
