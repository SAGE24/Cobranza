using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Service.Queries.DTOs;
using AutoMapper;

namespace Service.Queries;
public interface IDebtorQuery {
    Task<DebtorQueryResp> Get(string? fact);
}
public class DebtorQuery : IDebtorQuery
{
    private readonly AplicationDBContext _appContext;
    private readonly IMapper _imapper;
    public DebtorQuery(AplicationDBContext appContext, IMapper imapper) { 
        _appContext = appContext;
        _imapper = imapper;
    }
    public async Task<DebtorQueryResp> Get(string? fact) {
        fact ??= string.Empty;
        List<Domain.Debtor> lst = await (from d in _appContext.Debtor
                                         where d.Document.Contains(fact) || d.Name.Contains(fact) && d.Status
                                         select d).ToListAsync();
        DebtorQueryResp response = _imapper.Map<DebtorQueryResp>(lst);
        return response;
    }
}
