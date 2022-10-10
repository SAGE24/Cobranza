using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.EventHandler.Commands;
using Service.Queries;
using Service.Queries.DTOs;

namespace Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DebtorController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IDebtorQuery _iDebtorQuery;
    public DebtorController(IMediator mediator, IDebtorQuery iDebtorQuery) { 
        _mediator = mediator;
        _iDebtorQuery = iDebtorQuery;
    }

    /// <summary>
    /// Insertar datos de deudor.
    /// </summary>
    [HttpPost]
    public async Task<DebtorResp> Debtor(Debtor command) {
        return await _mediator.Send(command);
    }
    /// <summary>
    /// Modificar datos de deudor.
    /// </summary>
    [HttpPut]
    public async Task<DebtorResp> Update(DebtorUpdate command) {
        return await _mediator.Send(command);
    }
    /// <summary>
    /// Listar datos de deudor.
    /// </summary>
    [HttpGet("{fact?}")]
    public async Task<DebtorQueryResp> Get(string? fact = null) {
        return await _iDebtorQuery.Get(fact);
    }
    /// <summary>
    /// Inactivar registro de deudor.
    /// </summary>
    [HttpDelete]
    public async Task<DebtorResp> Delete(DebtorDelete command)
    {
        return await _mediator.Send(command);
    }
}
