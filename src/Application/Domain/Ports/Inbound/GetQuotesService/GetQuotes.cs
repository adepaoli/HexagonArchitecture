using Hexagon.Application.Domain.Models.Quotes;
using Hexagon.Application.Domain.Ports.Outbound;

namespace Hexagon.Application.Domain.Ports.Inbound.GetQuotesService;

public class GetQuotes : IGetQuotes
{
    private readonly IQuotesRepository _quotesRepository;

    public GetQuotes(IQuotesRepository quotesRepository)
    {
        _quotesRepository = quotesRepository;
    }

    public async Task<IEnumerable<Quote>> Execute()
    {
        var quotes = await _quotesRepository.GetQuotes();

        return quotes;

    }
}