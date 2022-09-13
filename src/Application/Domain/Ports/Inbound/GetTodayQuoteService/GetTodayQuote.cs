using Hexagon.Application.Domain.Models.Quotes;
using Hexagon.Application.Domain.Ports.Outbound;

namespace Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;

public class GetTodayQuote : IGetTodayQuote
{
    private readonly IQuotesRepository _quotesRepository;

    public GetTodayQuote(IQuotesRepository quotesRepository)
    {
        _quotesRepository = quotesRepository;
    }

    public async Task<Quote> Execute()
    {
        var quotes = await _quotesRepository.GetQuotes();

        var todayQuote = GetRandomQuote(quotes.ToList());

        return todayQuote;
    }

    private static Quote GetRandomQuote(IList<Quote> quotes)
    {
        var random = new Random();
        int index = random.Next(quotes.Count);

        var domainModel = quotes[index];
        return domainModel;
    }
}
