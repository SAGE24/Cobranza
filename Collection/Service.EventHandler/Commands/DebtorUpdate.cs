using MediatR;

namespace Service.EventHandler.Commands;
public class DebtorUpdate : IRequest<DebtorResp>
{
    public int DebtorCode { get; set; }
    public string Document { get; set; }
    public string DocumentType { get; set; }
    public string Name { get; set; }
    public DateTime? BirthdayDate { get; set; }
    public string? Work { get; set; }
    public decimal? Salary { get; set; }
    public string UserName { get; set; }
}
