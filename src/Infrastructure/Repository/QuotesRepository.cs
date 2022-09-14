using Hexagon.Application.Domain.Models.Quotes;
using Hexagon.Application.Domain.Ports.Outbound;
using Hexagon.Infrastructure.Services;

namespace Hexagon.Infrastructure.Repository
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly IQuotesDataSource _dataSource;

        public QuotesRepository(IQuotesDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public Task<IEnumerable<Quote>> GetQuotes()
        {
            return _dataSource.ReadAll();
        }
    }
}