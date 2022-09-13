using Hexagon.Application.UseCases.GetTodayQuoteUseCase;

namespace Hexagon.Console.Adapters
{
    public class ConsoleAdapter
    {
        private readonly IGetTodayQuoteUseCase _useCase;

        public ConsoleAdapter(IGetTodayQuoteUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task ShowTodayQuote()
        {
            // Adapt from the infrastructure to the domain

            // Call the business logic
            var response = await _useCase.Execute();

            // Adapt from domain to infrastructure
            var text = response.Quote.Text;
            var author = response.Quote.Author;

            System.Console.WriteLine($"{text}\n\n{author}");
        }
    }
}