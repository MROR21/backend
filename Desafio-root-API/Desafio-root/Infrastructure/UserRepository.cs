using Microsoft.EntityFrameworkCore;
using Desafio_root.Domain.Entities;
using Desafio_root.Domain.IRepository;

namespace Desafio_root.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var emailVO = Desafio_root.Domain.ValueObject.Email.Create(email);

            return await _context.Users.FirstOrDefaultAsync(u => u.Email == emailVO);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}