namespace Hexagon.Application.Domain.Models.Quotes;

public class Quote
{
    public string Text { get; private set; }
    public string Author { get; private set; }

    public Quote(string text, string author)
    {
        Text = text;
        Author = author;
    }

    public static Quote CreateDefaultQuote()
    {
        return CreateFromString("I want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)");
    }


    public static Quote CreateFromString(string textAndAuthor)
    {
        var lines = textAndAuthor.ReplaceLineEndings().Split(Environment.NewLine);

        if (string.IsNullOrEmpty(textAndAuthor))
        {
            throw new ArgumentException("You must specify the Quote and the Author");
        }

        var text = GetText(lines);
        var author = GetAuthor(lines);

        if (string.IsNullOrEmpty(author))
        {
            throw new ArgumentException("You must specify the Author");
        }

        return new Quote(text, author);
    }

    private static string GetText(string[] lines)
    {
        var text = string.Empty;

        for (int x = 0; x < lines.Length - 2; x++)
        {
            text = text + lines[x] + Environment.NewLine;
        }

        return text.Trim();
    }
    private static string GetAuthor(string[] lines)
    {
        return lines[lines.Length - 1].Trim();
    }

}