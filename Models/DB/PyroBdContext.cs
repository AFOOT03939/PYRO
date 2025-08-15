using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pyro.Models.DB;

public partial class PyroBdContext : DbContext
{
    public PyroBdContext()
    {
    }

    public PyroBdContext(DbContextOptions<PyroBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Foto> Fotos { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Membresium> Membresia { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Reaccion> Reaccions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-UPBDLM0;Initial Catalog=Pyro_BD;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdCom).HasName("PK__COMENTAR__5EE02F137B407736");

            entity.ToTable("COMENTARIO");

            entity.Property(e => e.IdCom).HasColumnName("Id_Com");
            entity.Property(e => e.DescCom)
                .HasMaxLength(500)
                .HasColumnName("Desc_Com");
            entity.Property(e => e.FechaCom)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Com");
            entity.Property(e => e.IdPost).HasColumnName("Id_Post");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COMENTARI__Id_Po__619B8048");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COMENTARI__Id_Us__628FA481");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => e.IdFollow).HasName("PK__FOLLOW__EBD59CE37184D9B4");

            entity.ToTable("FOLLOW");

            entity.HasIndex(e => new { e.IdSeguidor, e.IdSeguido }, "UQ_Follow").IsUnique();

            entity.Property(e => e.IdFollow).HasColumnName("Id_Follow");
            entity.Property(e => e.FechaFollow)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Follow");
            entity.Property(e => e.IdSeguido).HasColumnName("Id_Seguido");
            entity.Property(e => e.IdSeguidor).HasColumnName("Id_Seguidor");

            entity.HasOne(d => d.IdSeguidoNavigation).WithMany(p => p.FollowIdSeguidoNavigations)
                .HasForeignKey(d => d.IdSeguido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FOLLOW__Id_Segui__68487DD7");

            entity.HasOne(d => d.IdSeguidorNavigation).WithMany(p => p.FollowIdSeguidorNavigations)
                .HasForeignKey(d => d.IdSeguidor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FOLLOW__Id_Segui__6754599E");
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.IdFoto).HasName("PK__FOTO__E107B44E0906D796");

            entity.ToTable("FOTO");

            entity.Property(e => e.IdFoto).HasColumnName("Id_Foto");
            entity.Property(e => e.FechaFoto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Foto");
            entity.Property(e => e.IdPost).HasColumnName("Id_Post");
            entity.Property(e => e.LinkFoto)
                .HasMaxLength(500)
                .HasColumnName("Link_Foto");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FOTO__Id_Post__59063A47");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__GRUPO__ACDDD978D036FAD2");

            entity.ToTable("GRUPO");

            entity.Property(e => e.IdGrupo).HasColumnName("Id_Grupo");
            entity.Property(e => e.DescGrupo)
                .HasMaxLength(255)
                .HasColumnName("Desc_Grupo");
            entity.Property(e => e.FechaGrupo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Grupo");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GRUPO__Id_Usuari__4AB81AF0");
        });

        modelBuilder.Entity<Membresium>(entity =>
        {
            entity.HasKey(e => e.IdMember).HasName("PK__MEMBRESI__74E3FDA86BFD7C04");

            entity.ToTable("MEMBRESIA");

            entity.HasIndex(e => new { e.IdGrupo, e.IdUsuario }, "UQ_Membresia").IsUnique();

            entity.Property(e => e.IdMember).HasColumnName("Id_Member");
            entity.Property(e => e.FechaMember)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Member");
            entity.Property(e => e.IdGrupo).HasColumnName("Id_Grupo");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Membresia)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MEMBRESIA__Id_Gr__4F7CD00D");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Membresia)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MEMBRESIA__Id_Us__5070F446");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdPost).HasName("PK__POST__3B12A62145F8B471");

            entity.ToTable("POST");

            entity.Property(e => e.IdPost).HasColumnName("Id_Post");
            entity.Property(e => e.DescPost)
                .HasMaxLength(500)
                .HasColumnName("Desc_Post");
            entity.Property(e => e.EstadoPost).HasColumnName("Estado_Post");
            entity.Property(e => e.FechaPost)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Post");
            entity.Property(e => e.IdGrupo).HasColumnName("Id_Grupo");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK__POST__Id_Grupo__5535A963");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__POST__Id_Usuario__5441852A");
        });

        modelBuilder.Entity<Reaccion>(entity =>
        {
            entity.HasKey(e => e.IdReac).HasName("PK__REACCION__3743396C311FDB9B");

            entity.ToTable("REACCION");

            entity.Property(e => e.IdReac).HasColumnName("Id_Reac");
            entity.Property(e => e.FechaReac)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Reac");
            entity.Property(e => e.IdPost).HasColumnName("Id_Post");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Reaccions)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__REACCION__Id_Pos__5DCAEF64");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reaccions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__REACCION__Id_Usu__5CD6CB2B");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__63C76BE29622DDCF");

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.ApodoUsuario)
                .HasMaxLength(50)
                .HasColumnName("Apodo_Usuario");
            entity.Property(e => e.ContraUsuario)
                .HasMaxLength(100)
                .HasColumnName("Contra_Usuario");
            entity.Property(e => e.EstadoUsuario).HasColumnName("Estado_Usuario");
            entity.Property(e => e.FechaUsuario)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
