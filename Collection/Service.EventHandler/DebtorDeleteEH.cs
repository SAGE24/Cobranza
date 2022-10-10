using MediatR;
using Service.EventHandler.Commands;
using Persistence.Database;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Service.EventHandler;
public class DebtorDeleteEH : IRequestHandler<DebtorDelete, DebtorResp>
{
    private readonly AplicationDBContext _appContext;
    public DebtorDeleteEH(AplicationDBContext appContext)
    {
        _appContext = appContext;
    }

    public async Task<DebtorResp> Handle(DebtorDelete request, CancellationToken cancellationToken)
    {
        DebtorResp response = new();
        var register = await (from d in _appContext.Debtor
                             where d.DebtorCode == request.DebtorCode
                             select d).FirstOrDefaultAsync(cancellationToken);
        if (register != null)
        {
            register.Status = false;
            register.ModificationDate = DateTime.Now;
            register.ModifierUser = request.UserName;

            await _appContext.SaveChangesAsync(cancellationToken);

            response.Code = "0";
        }
        else {
            response.Code = "-1";
            response.Message = "Registro no existe.";
        }
        return response;
    }
}
