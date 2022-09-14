using Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;

namespace Hexagon.Console.Adapters
{
    public class TodayQuoteConsoleAdapter
    {
        private readonly IGetTodayQuote _getTodayQuoteService;

        public TodayQuoteConsoleAdapter(IGetTodayQuote getTodayQuoteService)
        {
            _getTodayQuoteService = getTodayQuoteService;
        }

        public async Task ShowQuote()
        {
            // 1. Validate infrastructure input

            // 2. Adapt from the infrastructure to the domain

            // 3. Call the business logic
            var response = await _getTodayQuoteService.Execute();

            // 4. Adapt from domain to infrastructure
            var text = response.Text;
            var author = "Author:" + response.Author;

            System.Console.WriteLine($"{text}\n\n{author}");
        }
    }
}