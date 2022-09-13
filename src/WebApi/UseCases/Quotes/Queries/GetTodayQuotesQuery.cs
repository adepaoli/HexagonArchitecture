using Hexagon.Application.UseCases.GetTodayQuoteUseCase;
using MediatR;

namespace Hexagonal.WebApi.UseCases.Quotes.Queries
{
    public class GetTodayQuoteQuery : IRequest<GetTodayQuoteResponse>
    {
    }

    public class GetTodayQuoteQueryHandler : IRequestHandler<GetTodayQuoteQuery, GetTodayQuoteResponse>
    {
        private readonly IGetTodayQuoteUseCase _useCase;

        public GetTodayQuoteQueryHandler(IGetTodayQuoteUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<GetTodayQuoteResponse> Handle(GetTodayQuoteQuery request, CancellationToken cancellationToken)
        {
            return await _useCase.Execute();
        }
    }

}
