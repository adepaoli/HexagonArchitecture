namespace Hexagon.Application.UseCases;

public class QuoteDto
{
    public string Text { get; set; }
    public string Author { get; set; }

    public QuoteDto()
    {
        Text = string.Empty;
        Author = string.Empty;
    }
}
