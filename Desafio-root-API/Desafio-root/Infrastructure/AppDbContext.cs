using Desafio_root.Domain.Entities;
using Desafio_root.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Desafio_root.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Email)
                      .HasConversion(
                          email => email.Value,      
                          value => Email.Create(value) 
                      )
                      .IsRequired();
            });

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                      .HasConversion(
                          title => title.Title,
                          value => TaskTitle.Create(value))
                      .IsRequired();

                entity.Property(e => e.Description);
                entity.Property(e => e.DueDate);
                entity.Property(e => e.Priority); 
                entity.Property(e => e.Status);

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(t => t.UserId);
            });
        }
    }
}