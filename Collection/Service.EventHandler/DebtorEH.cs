using MediatR;
using Service.EventHandler.Commands;
using Persistence.Database;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Service.EventHandler;
public class DebtorEH : IRequestHandler<Debtor, DebtorResp>
{
    private readonly IMapper _imapper;
    private readonly ILogger<DebtorEH> _logger;
    private readonly AplicationDBContext _appContext;
    public DebtorEH(IMapper imapper, ILogger<DebtorEH> logger, AplicationDBContext appContext) {
        _imapper = imapper;
        _logger = logger;
        _appContext = appContext;
    }
    public async Task<DebtorResp> Handle(Debtor request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Execute insert");
        Domain.Debtor debtor = _imapper.Map<Domain.Debtor>(request);
        debtor.CreatorUser = request.UserName;

        _appContext.Debtor.Add(debtor);
        await _appContext.SaveChangesAsync(cancellationToken);

        return new() {
            Code = "0",
            Message = "OK"
        };
    }
}
