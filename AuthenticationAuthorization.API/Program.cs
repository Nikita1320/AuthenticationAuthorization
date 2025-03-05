using AuthenticationAuthorization.Domain.Interfaces.RepositoryInterfaces;
using AuthenticationAuthorization.Infastructure;
using AuthenticationAuthorization.Persistence.Contexts;
using AuthenticationAuthorization.Persistence.Repositories;
using AuthenticationAuthorization.Services.Business;
using AuthenticationAuthorization.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AuthenticationAuthorization.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            
            var s = builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationContext>(otions =>
            {
                otions.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationContext)));
            });

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<AuthorizationService>();

            services.AddScoped<IJWTProvider, JWTProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            var app = builder.Build();

            app.MapUsersEndpoints();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Run();
        }
    }
}
