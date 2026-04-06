using Desafio_root.Application.DTOs;
using Desafio_root.Domain.Entities;
using Desafio_root.Domain.IRepository;
using Desafio_root.Domain.ValueObject;
using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims; 
using System.Text;

namespace Desafio_root.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _config;

        public UserService(IUserRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        public async Task<UserResponseDTO> LoginOrRegisterAsync(UserLoginDTO dto)
        {
            var emailValidate = Email.Create(dto.Email);
            var user = await _repository.GetByEmailAsync(emailValidate.Value);

            bool isNew = false;

            if (user != null)
            {
                if (!user.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Este e-mail já está vinculado a outro nome de usuário.");
                }
            }
            else
            {
                user = User.Create(dto.Name, emailValidate);
                await _repository.AddAsync(user);
                isNew = true;
            }

            var token = GenerateJwtToken(user);

            return new UserResponseDTO
            (
                user.Id,
                user.Name,
                user.Email.Value,
                token,
                isNew
            );
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"] ?? "Chave_Mestra_Super_Secreta_Miguel_2026");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.Value),
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = _config["Jwt:Issuer"], 
                Audience = _config["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
    
