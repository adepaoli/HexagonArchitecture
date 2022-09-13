using Hexagonal.WebApi.UseCases.Quotes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hexagonal.WebApi.Adapters;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuotesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/quotes", Name = "GetQuotes")]
    public async Task<IActionResult> GetQuotes()
    {
        var response = await _mediator.Send(new GetQuotesQuery());

        return Ok(response);
    }

    [HttpGet("/quotes/today", Name = "GetTodayQuote")]
    public async Task<IActionResult> GetTodayQuote()
    {
        var response = await _mediator.Send(new GetTodayQuoteQuery());

        return Ok(response);
    }
}
