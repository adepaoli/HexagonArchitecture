using Hexagon.Application.Domain.Models.Quotes;

namespace Hexagon.Application.Domain.Ports.Outbound;

public interface IQuotesDataSource
{
    Task<IEnumerable<Quote>> ReadAll();
}