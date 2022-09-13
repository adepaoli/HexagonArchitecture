using Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;
using Hexagon.Application.UseCases.GetTodayQuoteUseCase;
using Hexagon.Console.Adapters;
using Hexagon.Infrastructure.Repository;

Console.WriteLine("Welcome! I say that:");

// Instantiate the right-side adapter(s) - Outbound / Driven
var dataSource = new QuotesDataSourceFileAdapter(@".\Quotes.json");
var repository = new QuotesRepository(dataSource);
var service = new GetTodayQuote(repository);

// Instantiate the hexagon (with right-side adapter)
var useCase = new GetTodayQuoteUseCase(service);

// Instantiate the left-side adapter(s) - Inbound/ Driver
var consoleAdapter = new ConsoleAdapter(useCase);

// App logic is only using left-side adapter(s).
Console.WriteLine("---");
await consoleAdapter.ShowTodayQuote();
Console.WriteLine("---");

Console.WriteLine("Press return key to exit");

Console.ReadLine();
