using MediatR;
namespace Service.EventHandler.Commands;
public class Debtor : IRequest<DebtorResp>
{
    public string Document { get; set; }
    public string DocumentType { get; set; }
    public string Name { get; set; }
    public DateTime? BirthdayDate { get; set; }
    public string? Work { get; set; }
    public decimal? Salary { get; set; }
    public string UserName { get; set; }
}
public class DebtorResp : Response { }
