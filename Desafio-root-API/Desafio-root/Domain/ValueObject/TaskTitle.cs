using static System.Net.WebRequestMethods;

namespace Desafio_root.Domain.ValueObject
{
    public record TaskTitle
    {
        public string Title { get; init; }

        private TaskTitle(string title) 
        {
            Title = title; 
        }


        public static TaskTitle Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(" O Titulo não pode estar vazio.", nameof(title));

            if (title.Length > 100)
                throw new ArgumentException("Máximo de 100 caracteres", nameof(title));

            return new TaskTitle(title);
        }

}
}
