namespace Hexagonal.WebApi.Adapters.UseCases.Quotes.Queries.GetTodayQuote;

public class GetTodayQuoteResponse
{
    public string Text { get; set; }
    public string Author { get; set; }

    public GetTodayQuoteResponse()
    {
        Text = string.Empty;
        Author = string.Empty;
    }
}
