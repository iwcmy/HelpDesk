using HelpDesk.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HelpDesk.Api.Data;

public class HelpDeskDbContext : DbContext
{
    public HelpDeskDbContext(DbContextOptions<HelpDeskDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Comentario> Comentarios => Set<Comentario>();
    public DbSet<HistorialEstado> HistorialEstados => Set<HistorialEstado>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación: Ticket -> Cliente
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Cliente)
            .WithMany(u => u.TicketsCreados)
            .HasForeignKey(t => t.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación: Ticket -> AgenteAsignado 
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.AgenteAsignado)
            .WithMany(u => u.TicketsAsignados)
            .HasForeignKey(t => t.AgenteAsignadoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación: Ticket -> Categoria
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Categoria)
            .WithMany(c => c.Tickets)
            .HasForeignKey(t => t.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación: Comentario -> Ticket
        modelBuilder.Entity<Comentario>()
            .HasOne(c => c.Ticket)
            .WithMany(t => t.Comentarios)
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación: Comentario -> Autor
        modelBuilder.Entity<Comentario>()
            .HasOne(c => c.Autor)
            .WithMany()
            .HasForeignKey(c => c.AutorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación: HistorialEstado -> Ticket
        modelBuilder.Entity<HistorialEstado>()
            .HasOne(h => h.Ticket)
            .WithMany(t => t.Historial)
            .HasForeignKey(h => h.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación: HistorialEstado -> UsuarioQueCambio
        modelBuilder.Entity<HistorialEstado>()
            .HasOne(h => h.UsuarioQueCambio)
            .WithMany()
            .HasForeignKey(h => h.UsuarioQueCambioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}