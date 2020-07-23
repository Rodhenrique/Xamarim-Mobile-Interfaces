using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_Api.Models
{
    public partial class WSTower_appContext : DbContext
    {
        public WSTower_appContext()
        {
        }

        public WSTower_appContext(DbContextOptions<WSTower_appContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompraIngressos> CompraIngressos { get; set; }
        public virtual DbSet<Estadio> Estadio { get; set; }
        public virtual DbSet<FormaDePagamento> FormaDePagamento { get; set; }
        public virtual DbSet<Jogos> Jogos { get; set; }
        public virtual DbSet<Times> Times { get; set; }
        public virtual DbSet<TipoDeIngresso> TipoDeIngresso { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-OEOULMOC\\SQLEXPRESS;Database=WSTower_app;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CompraIngressos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Valor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFormaDePagamentoNavigation)
                    .WithMany(p => p.CompraIngressos)
                    .HasForeignKey(d => d.IdFormaDePagamento)
                    .HasConstraintName("FK__CompraIng__IdFor__47DBAE45");

                entity.HasOne(d => d.IdJogoNavigation)
                    .WithMany(p => p.CompraIngressosIdJogoNavigation)
                    .HasForeignKey(d => d.IdJogo)
                    .HasConstraintName("FK__CompraIng__IdJog__4AB81AF0");

                entity.HasOne(d => d.IdJogosNavigation)
                    .WithMany(p => p.CompraIngressosIdJogosNavigation)
                    .HasForeignKey(d => d.IdJogos)
                    .HasConstraintName("FK__CompraIng__IdJog__46E78A0C");

                entity.HasOne(d => d.IdTipoDeIngressoNavigation)
                    .WithMany(p => p.CompraIngressos)
                    .HasForeignKey(d => d.IdTipoDeIngresso)
                    .HasConstraintName("FK__CompraIng__IdTip__49C3F6B7");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.CompraIngressos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__CompraIng__IdUsu__48CFD27E");
            });

            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormaDePagamento>(entity =>
            {
                entity.HasKey(e => e.IdFormaDePagamento)
                    .HasName("PK__FormaDeP__12144A7FED5C7390");

                entity.Property(e => e.FormaDePagamento1)
                    .IsRequired()
                    .HasColumnName("Forma_de_Pagamento")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jogos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Campeonato)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Detalhes).HasColumnType("text");

                entity.Property(e => e.Endereço)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Horario)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Jogo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadioNavigation)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.IdEstadio)
                    .HasConstraintName("FK__Jogos__IdEstadio__440B1D61");

                entity.HasOne(d => d.IdTimeCasaNavigation)
                    .WithMany(p => p.JogosIdTimeCasaNavigation)
                    .HasForeignKey(d => d.IdTimeCasa)
                    .HasConstraintName("FK__Jogos__IdTimeCas__4316F928");

                entity.HasOne(d => d.IdTimeVisitanteNavigation)
                    .WithMany(p => p.JogosIdTimeVisitanteNavigation)
                    .HasForeignKey(d => d.IdTimeVisitante)
                    .HasConstraintName("FK__Jogos__IdTimeVis__4222D4EF");
            });

            modelBuilder.Entity<Times>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bandeira).HasColumnType("image");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDeIngresso>(entity =>
            {
                entity.HasKey(e => e.IdTipoDeIngresso)
                    .HasName("PK__TipoDeIn__F2745ADF8F595050");

                entity.Property(e => e.TipoDeIngresso1)
                    .IsRequired()
                    .HasColumnName("Tipo_de_Ingresso")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(12, 2)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.NomeUsuario)
                    .HasName("UQ__Usuario__06940B9AD30358B4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasColumnType("image");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
