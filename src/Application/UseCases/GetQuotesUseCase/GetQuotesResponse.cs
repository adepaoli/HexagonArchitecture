namespace Hexagon.Application.UseCases.GetQuotesUseCase;

public class GetQuotesResponse
{
    public IList<QuoteDto> Quotes { get; }

    public GetQuotesResponse()
    {
        Quotes = new List<QuoteDto>();
    }
}