namespace Hexagon.Application.UseCases.GetQuotesUseCase;

public interface IGetQuotesUseCase
{
    Task<GetQuotesResponse> Execute();
}
