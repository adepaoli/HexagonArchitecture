using FluentAssertions;
using Hexagon.Application.Domain.Models.Quotes;
using Hexagon.Application.Domain.Ports.Inbound.GetQuotesService;
using Hexagon.Application.Domain.Ports.Outbound;
using Moq;
using Moq.AutoMock;

namespace Hexagon.Application.Tests.Domain.Ports.Inbound.GetQuotesService;

public class GetQuotesTests
{
    [Fact]
    public async Task ShouldGiveQuoteWhenAskedForIt()
    {
        // Arrange
        var todayQuote = Quote.CreateFromString("Always turn a negative situation into a positive situation.\r\n\r\nMichael Jordan");

        var mocker = new AutoMocker();

        mocker.GetMock<IQuotesRepository>()
            .Setup(x => x.GetQuotes())
            .ReturnsAsync(new List<Quote>
            {
                todayQuote
            });

        // Act
        var useCase = mocker.CreateInstance<GetQuotes>();

        var response = await useCase.Execute();

        // Assert
        response.First().Text.Should().Be("Always turn a negative situation into a positive situation.");
        response.First().Author.Should().Be("Michael Jordan");
    }

}
