using Desafio_root.Domain.Entities;

namespace Desafio_root.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);

        Task AddAsync(User user);
    }
}
