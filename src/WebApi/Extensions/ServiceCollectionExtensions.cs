using Hexagon.Application.Domain.Ports.Inbound.GetQuotesService;
using Hexagon.Application.Domain.Ports.Inbound.GetTodayQuoteService;
using Hexagon.Application.Domain.Ports.Outbound;
using Hexagon.Application.UseCases.GetQuotesUseCase;
using Hexagon.Application.UseCases.GetTodayQuoteUseCase;
using Hexagon.Infrastructure.Repository;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using System.Reflection;

namespace Hexagonal.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPackages(this IServiceCollection services)
        {
            var domainAssembly = typeof(Program).GetTypeInfo().Assembly;

            // Add MediatR
            services.AddMediatR(new[] { domainAssembly });

            //Add FluentValidation
            services.AddFluentValidation(new[] { domainAssembly });

            //Add AutoMapper
            services.AddAutoMapper(new[] { domainAssembly });
            return services;
        }

        public static IServiceCollection AddDependecies(this IServiceCollection services)
        {
            var domainAssembly = typeof(QuotesDataSourceFileAdapter).GetTypeInfo().Assembly;
            var domainAssemblyPath = Directory.GetParent(domainAssembly.Location);

            var dataSource = new QuotesDataSourceFileAdapter(@$"{domainAssemblyPath}\Quotes.json");

            services.AddSingleton<IQuotesDataSource>(dataSource);
            
            services.AddTransient<IGetQuotes, GetQuotes>();
            services.AddTransient<IGetTodayQuote, GetTodayQuote>();

            services.AddTransient<IQuotesRepository, QuotesRepository>();

            services.AddTransient<IGetQuotesUseCase, GetQuotesUseCase>();
            services.AddTransient<IGetTodayQuoteUseCase, GetTodayQuoteUseCase>();

            return services;
        }
    }

}
