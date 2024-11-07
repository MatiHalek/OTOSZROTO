
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            builder.Services.AddScoped<IAdvertismentRepository, AdvertismentRepository>();
            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<IJwtService, JwtService>();

            // Register IEmailService with a transient lifetime
            builder.Services.AddTransient<IEmailService>(provider =>
                new EmailService(
                    smtpServer: builder.Configuration["Email:SmtpServer"]!,
                    smtpPort: int.Parse(builder.Configuration["Email:SmtpPort"]!),
                    smtpUser: builder.Configuration["Email:SmtpUser"]!,
                    smtpPass: builder.Configuration["Email:SmtpPass"]!,
                    fromEmail: builder.Configuration["Email:FromEmail"]!
                ));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("Connection string 'DefaultConnection' not found"));
            });

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowNuxtApp",
                    builder => builder
                        .WithOrigins("http://localhost:3000") // Nuxt app URL
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            var app = builder.Build();

            app.UseCors("AllowNuxtApp");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {   
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
