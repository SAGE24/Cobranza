using MediatR;
using Service.EventHandler.Commands;
using Persistence.Database;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Service.EventHandler;
public class DebtorUpdateEH : IRequestHandler<DebtorUpdate, DebtorResp>
{
    private readonly IMapper _imapper;
    private readonly ILogger<DebtorEH> _logger;
    private readonly AplicationDBContext _appContext;
    public DebtorUpdateEH(IMapper imapper, ILogger<DebtorEH> logger, AplicationDBContext appContext)
    {
        _imapper = imapper;
        _logger = logger;
        _appContext = appContext;
    }

    public async Task<DebtorResp> Handle(DebtorUpdate request, CancellationToken cancellationToken)
    {
        DebtorResp response = new();
        var register = await (from d in _appContext.Debtor
                              where d.DebtorCode == request.DebtorCode
                              select d).FirstOrDefaultAsync(cancellationToken);
        if (register != null)
        {
            register.Name = request.Name;
            register.BirthdayDate = request.BirthdayDate;
            register.Salary = request.Salary;
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
