using Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;
using Hexagon.Console.Adapters;
using Hexagon.Infrastructure.Repository;
using Hexagon.Infrastructure.Services;

Console.WriteLine("Welcome!");

// Instantiate the right-side adapter(s) - Outbound / Driven
var dataSource = new QuotesDataSourceFileProvider(@".\Quotes.json");
var repository = new QuotesRepository(dataSource);

// Instantiate the hexagon (with right-side adapter)
var service = new GetTodayQuote(repository);

// Instantiate the left-side adapter(s) - Inbound/ Driver
var todayQuoteConsoleAdapter = new TodayQuoteConsoleAdapter(service);

// App logic is only using left-side adapter(s).
Console.WriteLine("---");
await todayQuoteConsoleAdapter.ShowQuote();
Console.WriteLine("---");

Console.WriteLine("Press return key to exit");

Console.ReadLine();
