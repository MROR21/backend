using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    User? GetById(Guid id);

    IEnumerable<User> GetAll();

    void Add(User user);

    void Update(User user);

    void Delete(Guid id);
}