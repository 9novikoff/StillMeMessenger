using MassTransit;
using Microsoft.EntityFrameworkCore;
using StillMeBackend.MessengerAPI.DAL;

namespace StillMeBackend.MessengerAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<MessengerDbContext>(option => option.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));
        
        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        app.Run();
    }
}