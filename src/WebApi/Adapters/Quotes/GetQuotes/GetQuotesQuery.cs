using Hexagon.Application.Domain.Ports.Inbound.GetQuotesService;
using Hexagonal.WebApi.Adapters.UseCases.Quotes.Queries.GetTodayQuote;
using MediatR;

namespace Hexagonal.WebApi.Adapters.UseCases.Quotes.Queries.GetQuotes
{
    public class GetQuotesQuery : IRequest<GetQuotesResponse>
    {
    }

    public class GetQuotesQueryHandler : IRequestHandler<GetQuotesQuery, GetQuotesResponse>
    {
        private readonly IGetQuotes _getQuotesService;

        public GetQuotesQueryHandler(IGetQuotes getQuotesService)
        {
            _getQuotesService = getQuotesService;
        }

        public async Task<GetQuotesResponse> Handle(GetQuotesQuery request, CancellationToken cancellationToken)
        {
            // 1. Validate infrastructure input

            // 2. Adapt from the infrastructure to the domain

            // 3. Call the business logic
            var quotes = await _getQuotesService.Execute();

            // 4. Adapt from domain to infrastructure
            var response = new GetQuotesResponse();
            quotes.ToList().ForEach(x => response.Quotes.Add(new GetTodayQuoteResponse
            {
                Text = x.Text,
                Author = x.Author

            }));

            return response;
        }
    }
}
