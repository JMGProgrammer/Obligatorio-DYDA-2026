using Microsoft.EntityFrameworkCore;
using Reporteros.Api.Models;

namespace Reporteros.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Deporte> Deportes { get; set; }
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Competicion> Competiciones { get; set; }
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<EquipoTemporada> EquiposTemporada { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<EventoPartido> EventosPartido { get; set; }
        public DbSet<RevisionResultado> RevisionesResultado { get; set; }
        public DbSet<Fuente> Fuentes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<ArticuloDeporte> ArticulosDeporte { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RegistroAuditoria> RegistrosAuditoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Deporte
            var d = modelBuilder.Entity<Deporte>();
            d.HasKey(x => x.Id);
            d.Property(x => x.Slug).HasMaxLength(60).IsRequired();
            d.Property(x => x.Nombre).HasMaxLength(80).IsRequired();
            d.Property(x => x.Tipo).HasMaxLength(20).IsRequired();
            d.HasIndex(x => x.Slug).IsUnique();

            // Juego
            var j = modelBuilder.Entity<Juego>();
            j.HasKey(x => x.Id);
            j.Property(x => x.Slug).HasMaxLength(60).IsRequired();
            j.Property(x => x.Nombre).HasMaxLength(80).IsRequired();
            j.HasIndex(x => x.Slug).IsUnique();
            j.HasOne(x => x.Deporte).WithMany(x => x.Juegos).HasForeignKey(x => x.DeporteId).OnDelete(DeleteBehavior.Restrict);

            // Competicion
            var c = modelBuilder.Entity<Competicion>();
            c.HasKey(x => x.Id);
            c.Property(x => x.Nombre).HasMaxLength(120).IsRequired();
            c.Property(x => x.Ambito).HasMaxLength(40).IsRequired();
            c.Property(x => x.Formato).HasMaxLength(40).IsRequired();
            c.HasOne(x => x.Deporte).WithMany(x => x.Competiciones).HasForeignKey(x => x.DeporteId).OnDelete(DeleteBehavior.Restrict);
            c.HasOne(x => x.Juego).WithMany(x => x.Competiciones).HasForeignKey(x => x.JuegoId).OnDelete(DeleteBehavior.SetNull);

            // Temporada
            var t = modelBuilder.Entity<Temporada>();
            t.HasKey(x => x.Id);
            t.Property(x => x.Etiqueta).HasMaxLength(60).IsRequired();
            t.Property(x => x.Estado).HasMaxLength(20).IsRequired();
            t.HasOne(x => x.Competicion).WithMany(x => x.Temporadas).HasForeignKey(x => x.CompeticionId).OnDelete(DeleteBehavior.Restrict);
            t.HasIndex(x => new { x.CompeticionId, x.Inicio });

            // Equipo
            var e = modelBuilder.Entity<Equipo>();
            e.HasKey(x => x.Id);
            e.Property(x => x.Nombre).HasMaxLength(120).IsRequired();
            e.Property(x => x.Slug).HasMaxLength(80).IsRequired();
            e.Property(x => x.Region).HasMaxLength(60);
            e.Property(x => x.UrlLogo).HasMaxLength(300);
            e.HasIndex(x => x.Slug).IsUnique();

            // EquipoTemporada
            var et = modelBuilder.Entity<EquipoTemporada>();
            et.HasKey(x => x.Id);
            et.HasIndex(x => new { x.TemporadaId, x.EquipoId }).IsUnique();
            et.HasOne(x => x.Temporada).WithMany(x => x.EquiposTemporada).HasForeignKey(x => x.TemporadaId).OnDelete(DeleteBehavior.Restrict);
            et.HasOne(x => x.Equipo).WithMany(x => x.EquiposTemporada).HasForeignKey(x => x.EquipoId).OnDelete(DeleteBehavior.Restrict);

            // Fuente
            var f = modelBuilder.Entity<Fuente>();
            f.HasKey(x => x.Id);
            f.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            f.Property(x => x.Url).HasMaxLength(500);
            f.Property(x => x.Confianza).HasMaxLength(20);
            f.Property(x => x.Atribucion).HasMaxLength(200);

            // Partido
            var p = modelBuilder.Entity<Partido>();
            p.HasKey(x => x.Id);
            p.Property(x => x.Estado).HasMaxLength(20).IsRequired();
            p.HasIndex(x => new { x.TemporadaId, x.ProgramadoEn });
            p.HasIndex(x => new { x.Estado, x.PublicadoEn });
            p.HasOne(x => x.Temporada).WithMany(x => x.Partidos).HasForeignKey(x => x.TemporadaId).OnDelete(DeleteBehavior.Restrict);
            p.HasOne(x => x.EquipoLocal).WithMany(x => x.PartidosLocal).HasForeignKey(x => x.EquipoLocalId).OnDelete(DeleteBehavior.Restrict);
            p.HasOne(x => x.EquipoVisitante).WithMany(x => x.PartidosVisitante).HasForeignKey(x => x.EquipoVisitanteId).OnDelete(DeleteBehavior.Restrict);
            p.HasOne(x => x.Fuente).WithMany(x => x.Partidos).HasForeignKey(x => x.FuenteId).OnDelete(DeleteBehavior.SetNull);

            // EventoPartido
            var ep = modelBuilder.Entity<EventoPartido>();
            ep.HasKey(x => x.Id);
            ep.Property(x => x.TipoEvento).HasMaxLength(40).IsRequired();
            ep.Property(x => x.MinutoORonda).HasMaxLength(20);
            ep.HasOne(x => x.Partido).WithMany(x => x.Eventos).HasForeignKey(x => x.PartidoId).OnDelete(DeleteBehavior.Cascade);

            // RevisionResultado
            var rr = modelBuilder.Entity<RevisionResultado>();
            rr.HasKey(x => x.Id);
            rr.Property(x => x.AnteriorJson).IsRequired();
            rr.Property(x => x.NuevoJson).IsRequired();
            rr.Property(x => x.Motivo).HasMaxLength(500).IsRequired();
            rr.HasOne(x => x.Partido).WithMany(x => x.Revisiones).HasForeignKey(x => x.PartidoId).OnDelete(DeleteBehavior.Restrict);
            rr.HasOne(x => x.Editor).WithMany(x => x.Revisiones).HasForeignKey(x => x.EditorUsuarioId).OnDelete(DeleteBehavior.Restrict);

            // Usuario
            var u = modelBuilder.Entity<Usuario>();
            u.HasKey(x => x.Id);
            u.Property(x => x.Correo).HasMaxLength(200).IsRequired();
            u.Property(x => x.NombreMostrado).HasMaxLength(120).IsRequired();
            u.Property(x => x.Rol).HasMaxLength(30).IsRequired();
            u.HasIndex(x => x.Correo).IsUnique();

            // Articulo
            var a = modelBuilder.Entity<Articulo>();
            a.HasKey(x => x.Id);
            a.Property(x => x.Slug).HasMaxLength(120).IsRequired();
            a.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            a.Property(x => x.Resumen).HasMaxLength(500).IsRequired();
            a.Property(x => x.Cuerpo).IsRequired();
            a.Property(x => x.Estado).HasMaxLength(20).IsRequired();
            a.HasIndex(x => x.Slug).IsUnique();
            a.HasOne(x => x.Autor).WithMany(x => x.Articulos).HasForeignKey(x => x.AutorUsuarioId).OnDelete(DeleteBehavior.Restrict);

            // ArticuloDeporte
            var ad = modelBuilder.Entity<ArticuloDeporte>();
            ad.HasKey(x => new { x.ArticuloId, x.DeporteId });
            ad.HasOne(x => x.Articulo).WithMany(x => x.ArticulosDeporte).HasForeignKey(x => x.ArticuloId).OnDelete(DeleteBehavior.Cascade);
            ad.HasOne(x => x.Deporte).WithMany(x => x.ArticulosDeporte).HasForeignKey(x => x.DeporteId).OnDelete(DeleteBehavior.Restrict);

            // RegistroAuditoria
            var ra = modelBuilder.Entity<RegistroAuditoria>();
            ra.HasKey(x => x.Id);
            ra.Property(x => x.Accion).HasMaxLength(60).IsRequired();
            ra.Property(x => x.TipoEntidad).HasMaxLength(60).IsRequired();
            ra.HasOne(x => x.Actor).WithMany(x => x.RegistrosAuditoria).HasForeignKey(x => x.ActorUsuarioId).OnDelete(DeleteBehavior.Restrict);

            // Seed minimo de deportes
            d.HasData(
                new Deporte { Id = 1, Slug = "futbol", Nombre = "Fútbol", Tipo = "tradicional" },
                new Deporte { Id = 2, Slug = "basquetbol", Nombre = "Básquetbol", Tipo = "tradicional" },
                new Deporte { Id = 3, Slug = "esports", Nombre = "Esports", Tipo = "esports" }
            );
        }
    }
}
