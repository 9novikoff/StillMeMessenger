using MassTransit.Futures.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StillMeBackend.MessengerAPI.DAL;

public class MessengerDbContext : DbContext
{
    public MessengerDbContext(DbContextOptions<MessengerDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMember>()
            .HasKey(c => new { c.UserId, c.ChatId });
    }
    
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatMember> ChatMembers { get; set; }
    public DbSet<Message> Messages { get; set; }
}