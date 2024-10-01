using MAVIDI_SMILE.mavidiSmile.Domais.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVIDI_SMILE.mavidiSmile.Infrastructure.Data
{
    public class OdontoPrevContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Progresso> Progresso { get; set; }

        public OdontoPrevContext(DbContextOptions<OdontoPrevContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES"); 

                entity.HasKey(c => c.ClienteId);

                entity.Property(c => c.Nome)
                      .IsRequired()
                      .HasMaxLength(100)
                      .HasColumnType("VARCHAR2");

                entity.HasOne(c => c.Progresso)
                      .WithOne(p => p.Clientes)
                      .HasForeignKey<Progresso>(p => p.ProgressoId);
            });

            modelBuilder.Entity<Progresso>(entity =>
            {
                entity.ToTable("PROGRESSO");

                entity.HasKey(p => p.ProgressoId);

                entity.Property(p => p.Premios)
                      .IsRequired()
                      .HasColumnType("NUMBER");

                entity.HasOne(p => p.Clientes)
                      .WithOne(c => c.Progresso)
                      .HasForeignKey<Progresso>(p => p.ProgressoId);
            });
        }
    }
}
