using Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;
using MediatR;

namespace Hexagonal.WebApi.Adapters.UseCases.Quotes.Queries.GetTodayQuote
{
    public class GetTodayQuoteQuery : IRequest<GetTodayQuoteResponse>
    {
    }

    public class GetTodayQuoteQueryHandler : IRequestHandler<GetTodayQuoteQuery, GetTodayQuoteResponse>
    {
        private readonly IGetTodayQuote _getTodayQuoteService;

        public GetTodayQuoteQueryHandler(IGetTodayQuote getTodayQuoteService)
        {
            _getTodayQuoteService = getTodayQuoteService;
        }

        public async Task<GetTodayQuoteResponse> Handle(GetTodayQuoteQuery request, CancellationToken cancellationToken)
        {
            // 1. Validate infrastructure input

            // 2. Adapt from the infrastructure to the domain

            // 3. Call the business logic
            var todayQuote = await _getTodayQuoteService.Execute();

            // 4. Adapt from domain to infrastructure
            return new GetTodayQuoteResponse()
            {
                Text = todayQuote.Text,
                Author = todayQuote.Author

            };
        }
    }
}
