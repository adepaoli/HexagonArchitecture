using Hexagon.Application.Domain.Ports.Inbound.GetQuotesService;
using MediatR;

namespace Hexagonal.WebApi.Adapters.UseCases.Quotes.Queries
{
    public class GetQuotesQuery : IRequest<GetQuotesResponse>
    {
    }

    public class GetQuotesQueryHandler : IRequestHandler<GetQuotesQuery, GetQuotesResponse>
    {
        private readonly IGetQuotes _domainService;

        public GetQuotesQueryHandler(IGetQuotes domainService)
        {
            _domainService = domainService;
        }

        public async Task<GetQuotesResponse> Handle(GetQuotesQuery request, CancellationToken cancellationToken)
        {
            // Adapt from the infrastructure to the domain

            // Call the business logic
            var quotes = await _domainService.Execute();

            // Adapt from domain to infrastructure
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
