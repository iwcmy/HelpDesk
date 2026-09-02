using System.Net.Sockets;

namespace HelpDesk.Api.Models;

public enum RolUsuario
{
    Cliente,
    Agente,
    Administrador
}

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public RolUsuario Rol { get; set; }

    // Colecciones de navegación (lado "muchos" de las relaciones)
    public ICollection<Ticket> TicketsCreados { get; set; } = new List<Ticket>();
    public ICollection<Ticket> TicketsAsignados { get; set; } = new List<Ticket>();
}