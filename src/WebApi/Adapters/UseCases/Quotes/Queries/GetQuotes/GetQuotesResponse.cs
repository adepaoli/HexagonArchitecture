using Hexagonal.WebApi.Adapters.UseCases.Quotes.Queries.GetTodayQuote;

namespace Hexagonal.WebApi.Adapters.UseCases.Quotes.Queries.GetQuotes;

public class GetQuotesResponse
{
    public IList<GetTodayQuoteResponse> Quotes { get; }

    public GetQuotesResponse()
    {
        Quotes = new List<GetTodayQuoteResponse>();
    }
}
