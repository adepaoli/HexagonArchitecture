using FluentAssertions;
using Hexagon.Application.Domain.Models.Quotes;

namespace Hexagon.Application.Tests.Domain.Models;

public class QuoteTests
{
    [Fact]
    public void CreateQuoteWhenInputStringIsValid()
    {
        // Arrange
        var inputString = "Always turn a negative situation into a positive situation.\r\n\r\nMichael Jordan";

        // Act
        var quote = Quote.CreateFromString(inputString);

        // Assert
        quote.Text.Should().Be("Always turn a negative situation into a positive situation.");
        quote.Author.Should().Be("Michael Jordan");
    }

    [Fact]
    public void ThrowArgumentExceptionWhenInputStringIsEmpty()
    {
        // Arrange
        var inputString = string.Empty;

        // Act
        Action act = () => Quote.CreateFromString(inputString);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("You must specify the Quote and the Author");
    }

    [Fact]
    public void ThrowArgumentExceptionWhenAuthorIsEmpty()
    {
        // Arrange
        var inputString = "Always turn a negative situation into a positive situation.\r\n\r\n";

        // Act
        Action act = () => Quote.CreateFromString(inputString);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("You must specify the Author");
    }

}
