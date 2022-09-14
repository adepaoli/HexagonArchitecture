using Hexagon.Application.Domain.Models.Quotes;
using System.Text.Json;

namespace Hexagon.Infrastructure.Services
{
    public class QuotesDataSourceFileProvider : IQuotesDataSource
    {
        private readonly string _filePath;

        public QuotesDataSourceFileProvider(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<IEnumerable<Quote>> ReadAll()
        {
            var quotes = new List<Quote>();

            var jsonString = await File.ReadAllTextAsync(_filePath);

            var data = JsonSerializer.Deserialize<IEnumerable<QuoteDto>>(jsonString);
            if (data == null)
            {
                return new List<Quote>
                {
                    Quote.CreateDefaultQuote()
                };
            }

            data.ToList().ForEach(i => quotes.Add(new Quote(i.Text, i.Author)));

            return quotes;
        }
    }

    internal class QuoteDto
    {
        public string Text { get; set; }
        public string Author { get; set; }

        public QuoteDto()
        {
            Text = string.Empty;
            Author = string.Empty;

        }
    }
}