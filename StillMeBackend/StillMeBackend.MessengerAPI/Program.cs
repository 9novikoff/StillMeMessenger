using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using StillMeBackend.MessengerAPI.Consumers;
using StillMeBackend.MessengerAPI.DAL;
using StillMeBackend.MessengerAPI.DAL.Repositories;
using StillMeBackend.MessengerAPI.Services;

namespace StillMeBackend.MessengerAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddDbContext<MessengerDbContext>(option => option.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));

        builder.Services.AddScoped<ChatRepository>();
        builder.Services.AddScoped<MessageRepository>();

        builder.Services.AddScoped(s => 
            new ChatService(s.GetRequiredService<ChatRepository>(), s.GetRequiredService<IMapper>()));
        builder.Services.AddScoped(s =>
            new MessageService(s.GetRequiredService<MessageRepository>(), s.GetRequiredService<IMapper>()));
        
        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<ChatListGetConsumer>();
            x.AddConsumer<MessageCreateConsumer>();
            x.AddConsumer<MessageGetPageConsumer>();
            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                
                cfg.ConfigureEndpoints(context);
            });
        });
        
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