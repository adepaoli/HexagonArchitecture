using Hexagon.Application.Domain.Models.Quotes;

namespace Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;

public interface IGetTodayQuote
{
    Task<Quote> Execute();
}