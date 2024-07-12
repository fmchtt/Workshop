using Castle.Core.Smtp;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Application.Behavior;
using Workshop.Domain.Contracts;
using Workshop.Domain.Repositories;
using Workshop.Domain.Utils;
using Workshop.Infra.Behaviors;
using Workshop.Infra.Contexts;
using Workshop.Infra.Repositories;
using Workshop.Infra.Utils;

namespace Workshop.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Database configurations
        services.AddDbContext<WorkshopDBContext>(
            options =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    b => b.MigrationsAssembly(typeof(WorkshopDBContext).Assembly.FullName).UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery)
                );
            }
        );

        // Mediatr configurations
        services.AddMediatR(x => x.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Workshop.Application")));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

        // FluentValidation configurations
        services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Workshop.Application"));

        // Utils configurations
        services.AddTransient<IHasher, BCryptHasher>();
        services.AddTransient<ITokenService, TokenService>(x => new TokenService(configuration.GetValue<string>("SecretKey") ?? Guid.NewGuid().ToString()));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IEmailService, EmailService>();

        // Repositories configuration
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICompanyRepository, CompanyRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IPermissionRepository, PermissionRepository>();
        services.AddTransient<IProductInOrderRepository, ProductInOrderRepository>();
        services.AddTransient<IInvitationRepository, InvitationRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<IWorkRepository, WorkRepository>();
        services.AddTransient<IWorkInOrderRepository, WorkInOrderRepository>();

        // Mappers configuration
        services.AddAutoMapper(AppDomain.CurrentDomain.Load("Workshop.Infra"));

        //Fluent Email
        services
            .AddFluentEmail("fromemail@test.test")
            .AddSmtpSender("localhost", 25);

        return services;
    }
}
