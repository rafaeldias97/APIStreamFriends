using APIStreamFriends.domain.domain.Models;
using Microsoft.EntityFrameworkCore;

namespace APIStreamFriends.infra.Data.MSSQL.Context
{
    public class MSContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Seguidor> Seguidor { get; set; }

        public MSContext(DbContextOptions<MSContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(q =>
            {
                q.ToTable("Cliente").HasKey(x => x.id);
            });

            modelBuilder.Entity<Seguidor>(q =>
            {
                q.ToTable("Seguidor").HasKey(x => x.id);
            });
        }
    }
}
