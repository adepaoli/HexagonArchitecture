using Hexagon.Application.Domain.Models.Quotes;

namespace Hexagon.Application.Domain.Ports.Inbound.GetQuotesService;

public interface IGetQuotes
{
    Task<IEnumerable<Quote>> Execute();
}
