using FluentAssertions;
using Hexagon.Application.Domain.Models.Quotes;
using Hexagon.Application.Domain.Ports.Inbound.GetQuotesService;
using Hexagon.Application.UseCases.GetTodayQuoteUseCase;
using Moq;
using Moq.AutoMock;

namespace Hexagon.Application.Tests.UsesCases;

public class GetQuotesUseCaseTests
{
    [Fact]
    public async Task ShouldGiveQuoteWhenAskedForIt()
    {
        // Arrange
        var todayQuote = Quote.CreateFromString("Always turn a negative situation into a positive situation.\r\n\r\nMichael Jordan");

        var mocker = new AutoMocker();

        mocker.GetMock<IGetQuotes>()
            .Setup(x => x.Execute())
            .ReturnsAsync(new List<Quote>
            {
                todayQuote
            });

        // Act
        var useCase = mocker.CreateInstance<GetTodayQuoteUseCase>();

        var response = await useCase.Execute();

        // Assert
        response.Quote.Text.Should().Be("Always turn a negative situation into a positive situation.");
        response.Quote.Author.Should().Be("Michael Jordan");
    }
}
