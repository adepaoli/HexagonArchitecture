using Hexagon.Application.Domain.Models.Quotes;

namespace Hexagon.Application.Domain.Ports.Outbound
{
    public interface IQuotesRepository
    {
        Task<IEnumerable<Quote>> GetQuotes();
    }

}