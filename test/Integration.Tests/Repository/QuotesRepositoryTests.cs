using FluentAssertions;
using Hexagon.Application.Domain.Models.Quotes;
using Hexagon.Infrastructure.Repository;
using Hexagon.Infrastructure.Services;
using Moq;
using Moq.AutoMock;

namespace Hexagon.Integration.Tests.Repository;

public class QuotesRepositoryTests
{
    [Fact]
    public async Task ShouldGiveListOfQuoteWhenAskedForIt()
    {
        // Arrange
        var mocker = new AutoMocker();
        var quotesService = mocker.CreateInstance<QuotesRepository>();

        var dataSource = new List<Quote> {
                Quote.CreateDefaultQuote()
            };

        mocker.GetMock<IQuotesDataSource>()
            .Setup(x => x.ReadAll())
            .ReturnsAsync(dataSource);

        // Act
        var quotes = await quotesService.GetQuotes();

        // Assert
        quotes.Should().HaveCount(dataSource.Count);
    }

    [Fact]
    public async Task ShouldGiveQuotesWhenAskedForItFromLocalFile()
    {
        // Arrange
        var dataSource = new QuotesDataSourceFileProvider(@".\Quotes.json");

        var mocker = new AutoMocker();

        mocker.Use<IQuotesDataSource>(dataSource);

        var quotesService = mocker.CreateInstance<QuotesRepository>();

        // Act
        var quotes = await quotesService.GetQuotes();

        // Assert
        quotes.Should().NotBeEmpty();

    }

}
