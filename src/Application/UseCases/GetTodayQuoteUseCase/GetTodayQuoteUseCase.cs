using Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;

namespace Hexagon.Application.UseCases.GetTodayQuoteUseCase;

public class GetTodayQuoteUseCase : IGetTodayQuoteUseCase
{
    private readonly IGetTodayQuote _service;

    public GetTodayQuoteUseCase(IGetTodayQuote service)
    {
        _service = service;
    }

    public async Task<GetTodayQuoteResponse> Execute()
    {
        var todayQuote = await _service.Execute();

        return new GetTodayQuoteResponse
        {
            Quote = new QuoteDto
            {
                Text = todayQuote.Text,
                Author = todayQuote.Author
            }
        };
    }
}
