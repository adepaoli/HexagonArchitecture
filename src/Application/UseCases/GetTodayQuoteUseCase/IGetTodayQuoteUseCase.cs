namespace Hexagon.Application.UseCases.GetTodayQuoteUseCase;

public interface IGetTodayQuoteUseCase
{
    Task<GetTodayQuoteResponse> Execute();
}