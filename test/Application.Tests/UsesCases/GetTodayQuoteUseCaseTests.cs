using FluentAssertions;
using Hexagon.Application.Domain.Models.Quotes;
using Hexagon.Application.Domain.Ports.Outbound;
using Hexagon.Application.UseCases.GetTodayQuoteUseCase;
using Hexagon.Infrastructure.Repository;
using Moq;
using Moq.AutoMock;

namespace Hexagon.Application.Tests.UsesCases;

public class GetTodayQuoteUseCaseTests
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
        var useCase = mocker.CreateInstance<GetTodayQuoteUseCase>();

        var response = await useCase.Execute();

        // Assert
        response.Quote.Text.Should().Be("Always turn a negative situation into a positive situation.");
        response.Quote.Author.Should().Be("Michael Jordan");
    }


    [Fact]
    public async Task ShouldGiveQuoteWhenAskedForItFromLocalFile()
    {
        // Arrange
        var dataSource = new QuotesDataSourceFileAdapter(@".\Quotes.json");
        var repository = new QuotesRepository(dataSource);

        var mocker = new AutoMocker();
        mocker.Use<IQuotesRepository>(repository);

        // Act
        var useCase = mocker.CreateInstance<GetTodayQuoteUseCase>();

        var response = await useCase.Execute();

        // Assert
        response.Quote.Text.Should().NotBeNullOrEmpty();
        response.Quote.Author.Should().NotBeNullOrEmpty();
    }
}
