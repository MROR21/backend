using System.Text.RegularExpressions;

namespace Desafio_root.Domain.ValueObject
{
    public record Email
    {
        public string Value { get; init; }

        private Email(string value) {

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("O e-mail não pode estar vazio.");

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!regex.IsMatch(value))
                throw new ArgumentException("Formato de e-mail inválido. O e-mail deve conter '@' e um domínio válido.");

            Value = value.ToLower().Trim();
        }

        public static Email Create(string value)
        {
            return new Email(value);
        }
    }
}
