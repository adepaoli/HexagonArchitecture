using Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;
using MediatR;

namespace Hexagonal.WebApi.Adapters.UseCases.Quotes.Queries
{
    public class GetTodayQuoteQuery : IRequest<GetTodayQuoteResponse>
    {
    }

    public class GetTodayQuoteQueryHandler : IRequestHandler<GetTodayQuoteQuery, GetTodayQuoteResponse>
    {
        private readonly IGetTodayQuote _domainService;

        public GetTodayQuoteQueryHandler(IGetTodayQuote domainService)
        {
            _domainService = domainService;
        }

        public async Task<GetTodayQuoteResponse> Handle(GetTodayQuoteQuery request, CancellationToken cancellationToken)
        {
            // Adapt from the infrastructure to the domain

            // Call the business logic
            var todayQuote = await _domainService.Execute();

            // Adapt from domain to infrastructure
            return new GetTodayQuoteResponse()
            {
                Text = todayQuote.Text,
                Author = todayQuote.Author

            };
        }
    }
}
