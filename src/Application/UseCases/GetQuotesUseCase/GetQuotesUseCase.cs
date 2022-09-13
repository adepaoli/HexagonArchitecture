using Hexagon.Application.Domain.Ports.Inbound.GetQuotesService;

namespace Hexagon.Application.UseCases.GetQuotesUseCase;

public class GetQuotesUseCase : IGetQuotesUseCase
{
    private readonly IGetQuotes _domainService;

    public GetQuotesUseCase(IGetQuotes domainService)
    {
        _domainService = domainService;
    }

    public async Task<GetQuotesResponse> Execute()
    {
        var response = new GetQuotesResponse();

        var quotes = await _domainService.Execute();

        quotes.ToList().ForEach(x => response.Quotes.Add(new QuoteDto
        {
            Text = x.Text,
            Author = x.Author

        }));

        return response;
    }
}