namespace HelpDesk.Api.Models;

public class HistorialEstado
{
    public int Id { get; set; }
    public EstadoTicket EstadoAnterior { get; set; }
    public EstadoTicket EstadoNuevo { get; set; }
    public DateTime FechaCambio { get; set; } = DateTime.UtcNow;

    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    public int UsuarioQueCambioId { get; set; }
    public Usuario UsuarioQueCambio { get; set; } = null!;
}