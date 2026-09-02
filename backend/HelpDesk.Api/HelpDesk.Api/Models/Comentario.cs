namespace HelpDesk.Api.Models;

public class Comentario
{
    public int Id { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    public int AutorId { get; set; }
    public Usuario Autor { get; set; } = null!;
}