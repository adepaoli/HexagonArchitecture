using Hexagon.Application.Domain.Models.Quotes;

namespace Hexagon.Infrastructure.Services;

public interface IQuotesDataSource
{
    Task<IEnumerable<Quote>> ReadAll();
}