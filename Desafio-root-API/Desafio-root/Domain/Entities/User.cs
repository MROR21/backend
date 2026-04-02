using Desafio_root.Domain.ValueObject;

namespace Desafio_root.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }

        protected User() { }

        private User(string name, Email email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public static User Create(string name, Email email)
        {
            return new User(name, email);
        }
    }
}
