namespace HelpDesk.Api.Models;

public enum EstadoTicket
{
    Abierto,
    EnProgreso,
    Resuelto,
    Cerrado
}

public enum PrioridadTicket
{
    Baja,
    Media,
    Alta
}

public class Ticket
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public EstadoTicket Estado { get; set; } = EstadoTicket.Abierto;
    public PrioridadTicket Prioridad { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    // Relación con el cliente que creó el ticket
    public int ClienteId { get; set; }
    public Usuario Cliente { get; set; } = null!;

    // Relación con el agente asignado 
    public int? AgenteAsignadoId { get; set; }
    public Usuario? AgenteAsignado { get; set; }

    // Relación con la categoría
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = null!;

    public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    public ICollection<HistorialEstado> Historial { get; set; } = new List<HistorialEstado>();
}