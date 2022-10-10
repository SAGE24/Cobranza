using MediatR;

namespace Service.EventHandler.Commands;
public class DebtorDelete : IRequest<DebtorResp>
{
    public int DebtorCode { get; set; }
    public string UserName { get; set; }
}
