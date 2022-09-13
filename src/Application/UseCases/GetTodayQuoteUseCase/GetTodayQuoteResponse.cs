namespace Hexagon.Application.UseCases.GetTodayQuoteUseCase;

public class GetTodayQuoteResponse
{
    public QuoteDto Quote { get; set; }

    public GetTodayQuoteResponse()
    {
        Quote = new QuoteDto();
    }
}
