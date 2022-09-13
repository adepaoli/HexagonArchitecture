namespace Hexagonal.WebApi.Adapters.UseCases.Quotes.Queries;

public class GetQuotesResponse
{
    public IList<GetTodayQuoteResponse> Quotes { get; }

    public GetQuotesResponse()
    {
        Quotes = new List<GetTodayQuoteResponse>();
    }
}
