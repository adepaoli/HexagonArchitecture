using Hexagon.Application.UseCases.GetQuotesUseCase;
using MediatR;

namespace Hexagonal.WebApi.UseCases.Quotes.Queries
{
    public class GetQuotesQuery : IRequest<GetQuotesResponse>
    {
    }

    public class GetQuotesQueryHandler : IRequestHandler<GetQuotesQuery, GetQuotesResponse>
    {
        private readonly IGetQuotesUseCase _useCase;

        public GetQuotesQueryHandler(IGetQuotesUseCase useCase)
        {
            _useCase = useCase;
        }

        public Task<GetQuotesResponse> Handle(GetQuotesQuery request, CancellationToken cancellationToken)
        {
            return _useCase.Execute();
        }
    }
}
