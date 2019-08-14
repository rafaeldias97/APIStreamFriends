using Microsoft.EntityFrameworkCore;

namespace APIStreamFriends.infra.Data.MSSQL.Context
{
    public class MSContext : DbContext
    {
        //public DbSet<Transacao> Transacao { get; set; }

        public MSContext(DbContextOptions<MSContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Transacao>(q =>
            //{
            //    q.ToTable("Transacao").HasKey(x => x.id);
            //});
        }
    }
}
