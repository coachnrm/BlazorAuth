using Microsoft.EntityFrameworkCore;

namespace BlazorAuth.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<User> Users { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => 
            {
                entity.HasKey(e => e.Email);
                entity.ToTable("User");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }

}