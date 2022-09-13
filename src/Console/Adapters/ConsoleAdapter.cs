using Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;

namespace Hexagon.Console.Adapters
{
    public class ConsoleAdapter
    {
        private readonly IGetTodayQuote _service;

        public ConsoleAdapter(IGetTodayQuote service)
        {
            _service = service;
        }

        public async Task ShowTodayQuote()
        {
            // Adapt from the infrastructure to the domain

            // Call the business logic
            var response = await _service.Execute();

            // Adapt from domain to infrastructure
            var text = response.Text;
            var author = "Author:" + response.Author;

            System.Console.WriteLine($"{text}\n\n{author}");
        }
    }
}