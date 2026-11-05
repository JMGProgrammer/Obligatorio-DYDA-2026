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

            // Seed: juego esports
            modelBuilder.Entity<Juego>().HasData(
                new Juego { Id = 1, Slug = "league-of-legends", Nombre = "League of Legends", DeporteId = 3 }
            );

            // Seed: usuarios (roles)
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Correo = "admin@reporteros.uy", NombreMostrado = "Admin", Rol = "admin", PasswordHash = "AQAAAAEAACcQAAAAEPFtpYysK++ZyMuQ4lXZGumfPzGNLmx7Rn08JNT8JuT/mj8xjDBo5jgxqN3LjVobpw==" },
                new Usuario { Id = 2, Correo = "editor@reporteros.uy", NombreMostrado = "Editor", Rol = "editor", PasswordHash = "AQAAAAEAACcQAAAAEPFtpYysK++ZyMuQ4lXZGumfPzGNLmx7Rn08JNT8JuT/mj8xjDBo5jgxqN3LjVobpw==" },
                new Usuario { Id = 3, Correo = "revisor@reporteros.uy", NombreMostrado = "Revisor", Rol = "revisor", PasswordHash = "AQAAAAEAACcQAAAAEPFtpYysK++ZyMuQ4lXZGumfPzGNLmx7Rn08JNT8JuT/mj8xjDBo5jgxqN3LjVobpw==" },
                new Usuario { Id = 4, Correo = "visitante@reporteros.uy", NombreMostrado = "Visitante", Rol = "visitante", PasswordHash = "AQAAAAEAACcQAAAAEPFtpYysK++ZyMuQ4lXZGumfPzGNLmx7Rn08JNT8JuT/mj8xjDBo5jgxqN3LjVobpw==" }
            );

            // Seed: fuentes
            modelBuilder.Entity<Fuente>().HasData(
                new Fuente { Id = 1, Titulo = "Acta oficial AUF", Url = "https://auf.org.uy", Confianza = "alta", Atribucion = "AUF" },
                new Fuente { Id = 2, Titulo = "Carga manual editor", Confianza = "media", Atribucion = "Equipo editorial" }
            );

            // Seed: competiciones
            modelBuilder.Entity<Competicion>().HasData(
                new Competicion { Id = 1, DeporteId = 1, Nombre = "Campeonato Uruguayo", Ambito = "nacional", Formato = "liga" },
                new Competicion { Id = 2, DeporteId = 2, Nombre = "Liga Uruguaya de Básquetbol", Ambito = "nacional", Formato = "liga" },
                new Competicion { Id = 3, DeporteId = 3, JuegoId = 1, Nombre = "Liga Uruguaya de LoL", Ambito = "nacional", Formato = "liga" }
            );

            // Seed: temporadas
            modelBuilder.Entity<Temporada>().HasData(
                new Temporada { Id = 1, CompeticionId = 1, Etiqueta = "2026", Inicio = new DateTime(2026, 3, 1, 0, 0, 0, DateTimeKind.Utc), Fin = new DateTime(2026, 11, 30, 0, 0, 0, DateTimeKind.Utc), Estado = "en_curso" },
                new Temporada { Id = 2, CompeticionId = 2, Etiqueta = "2026", Inicio = new DateTime(2026, 4, 1, 0, 0, 0, DateTimeKind.Utc), Fin = new DateTime(2026, 12, 15, 0, 0, 0, DateTimeKind.Utc), Estado = "en_curso" },
                new Temporada { Id = 3, CompeticionId = 3, Etiqueta = "2026 Split 1", Inicio = new DateTime(2026, 5, 1, 0, 0, 0, DateTimeKind.Utc), Fin = new DateTime(2026, 8, 31, 0, 0, 0, DateTimeKind.Utc), Estado = "en_curso" }
            );

            // Seed: equipos
            modelBuilder.Entity<Equipo>().HasData(
                new Equipo { Id = 1, Nombre = "Peñarol", Slug = "penarol", Region = "Montevideo" },
                new Equipo { Id = 2, Nombre = "Nacional", Slug = "nacional", Region = "Montevideo" },
                new Equipo { Id = 3, Nombre = "Defensor Sporting", Slug = "defensor-sporting", Region = "Montevideo" },
                new Equipo { Id = 4, Nombre = "Liverpool", Slug = "liverpool", Region = "Montevideo" },
                new Equipo { Id = 5, Nombre = "Aguada", Slug = "aguada", Region = "Montevideo" },
                new Equipo { Id = 6, Nombre = "Malvín", Slug = "malvin", Region = "Montevideo" },
                new Equipo { Id = 7, Nombre = "Team Alpha", Slug = "team-alpha", Region = "Montevideo" },
                new Equipo { Id = 8, Nombre = "Team Beta", Slug = "team-beta", Region = "Montevideo" }
            );

            // Seed: inscripciones equipo-temporada
            modelBuilder.Entity<EquipoTemporada>().HasData(
                new EquipoTemporada { Id = 1, TemporadaId = 1, EquipoId = 1 },
                new EquipoTemporada { Id = 2, TemporadaId = 1, EquipoId = 2 },
                new EquipoTemporada { Id = 3, TemporadaId = 1, EquipoId = 3 },
                new EquipoTemporada { Id = 4, TemporadaId = 1, EquipoId = 4 },
                new EquipoTemporada { Id = 5, TemporadaId = 2, EquipoId = 5 },
                new EquipoTemporada { Id = 6, TemporadaId = 2, EquipoId = 6 },
                new EquipoTemporada { Id = 7, TemporadaId = 3, EquipoId = 7 },
                new EquipoTemporada { Id = 8, TemporadaId = 3, EquipoId = 8 }
            );

            // Seed: partidos (distintos estados)
            modelBuilder.Entity<Partido>().HasData(
                new Partido { Id = 1, TemporadaId = 1, EquipoLocalId = 1, EquipoVisitanteId = 2, ProgramadoEn = new DateTime(2026, 9, 10, 20, 0, 0, DateTimeKind.Utc), Estado = "programado", Version = 1, ActualizadoEn = new DateTime(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Partido { Id = 2, TemporadaId = 1, EquipoLocalId = 3, EquipoVisitanteId = 4, ProgramadoEn = new DateTime(2026, 8, 20, 19, 0, 0, DateTimeKind.Utc), Estado = "finalizado", PuntosLocal = 2, PuntosVisitante = 1, Version = 2, FuenteId = 1, PublicadoEn = new DateTime(2026, 8, 20, 21, 0, 0, DateTimeKind.Utc), ActualizadoEn = new DateTime(2026, 8, 20, 21, 0, 0, DateTimeKind.Utc) },
                new Partido { Id = 3, TemporadaId = 1, EquipoLocalId = 1, EquipoVisitanteId = 3, ProgramadoEn = new DateTime(2026, 8, 27, 20, 0, 0, DateTimeKind.Utc), Estado = "finalizado", PuntosLocal = 1, PuntosVisitante = 1, Version = 1, FuenteId = 1, PublicadoEn = new DateTime(2026, 8, 27, 22, 0, 0, DateTimeKind.Utc), ActualizadoEn = new DateTime(2026, 8, 27, 22, 0, 0, DateTimeKind.Utc) },
                new Partido { Id = 4, TemporadaId = 1, EquipoLocalId = 2, EquipoVisitanteId = 4, ProgramadoEn = new DateTime(2026, 9, 3, 16, 0, 0, DateTimeKind.Utc), Estado = "suspendido", Version = 1, ActualizadoEn = new DateTime(2026, 9, 3, 16, 30, 0, DateTimeKind.Utc) },
                new Partido { Id = 5, TemporadaId = 1, EquipoLocalId = 1, EquipoVisitanteId = 4, ProgramadoEn = new DateTime(2026, 9, 17, 20, 0, 0, DateTimeKind.Utc), Estado = "provisional", PuntosLocal = 2, PuntosVisitante = 0, Version = 1, FuenteId = 2, ActualizadoEn = new DateTime(2026, 9, 17, 22, 0, 0, DateTimeKind.Utc) },
                new Partido { Id = 6, TemporadaId = 2, EquipoLocalId = 5, EquipoVisitanteId = 6, ProgramadoEn = new DateTime(2026, 9, 5, 21, 0, 0, DateTimeKind.Utc), Estado = "finalizado", PuntosLocal = 85, PuntosVisitante = 80, Version = 1, FuenteId = 1, PublicadoEn = new DateTime(2026, 9, 5, 23, 0, 0, DateTimeKind.Utc), ActualizadoEn = new DateTime(2026, 9, 5, 23, 0, 0, DateTimeKind.Utc) },
                new Partido { Id = 7, TemporadaId = 2, EquipoLocalId = 6, EquipoVisitanteId = 5, ProgramadoEn = new DateTime(2026, 9, 12, 21, 0, 0, DateTimeKind.Utc), Estado = "programado", Version = 1, ActualizadoEn = new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Partido { Id = 8, TemporadaId = 3, EquipoLocalId = 7, EquipoVisitanteId = 8, ProgramadoEn = new DateTime(2026, 6, 10, 18, 0, 0, DateTimeKind.Utc), Estado = "finalizado", PuntosLocal = 2, PuntosVisitante = 1, MejorDe = 3, Version = 1, FuenteId = 1, PublicadoEn = new DateTime(2026, 6, 10, 20, 0, 0, DateTimeKind.Utc), ActualizadoEn = new DateTime(2026, 6, 10, 20, 0, 0, DateTimeKind.Utc) },
                new Partido { Id = 9, TemporadaId = 3, EquipoLocalId = 8, EquipoVisitanteId = 7, ProgramadoEn = new DateTime(2026, 6, 17, 18, 0, 0, DateTimeKind.Utc), Estado = "programado", MejorDe = 3, Version = 1, ActualizadoEn = new DateTime(2026, 6, 1, 0, 0, 0, DateTimeKind.Utc) }
            );

            // Seed: articulos
            modelBuilder.Entity<Articulo>().HasData(
                new Articulo { Id = 1, AutorUsuarioId = 2, Slug = "bienvenida-reporteros", Titulo = "Bienvenidos a REPORTEROS", Resumen = "El deporte uruguayo tiene quien lo cuente.", Cuerpo = "Contenido de bienvenida.", Estado = "publicado", PublicadoEn = new DateTime(2026, 8, 1, 12, 0, 0, DateTimeKind.Utc), ActualizadoEn = new DateTime(2026, 8, 1, 12, 0, 0, DateTimeKind.Utc) },
                new Articulo { Id = 2, AutorUsuarioId = 2, Slug = "borrador-noticia", Titulo = "Borrador de noticia", Resumen = "Resumen borrador.", Cuerpo = "Cuerpo borrador.", Estado = "borrador", ActualizadoEn = new DateTime(2026, 8, 2, 12, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<ArticuloDeporte>().HasData(
                new ArticuloDeporte { ArticuloId = 1, DeporteId = 1 }
            );
        }
    }
}
