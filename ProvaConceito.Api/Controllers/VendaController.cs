using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaConceito.Domain.Enum;
using ProvaConceito.Domain.Models;
using ProvaConceito.Domain.Models.OutParameters;
using ProvaConceito.Domain.Services;
using ProvaConceito.Domain.Services.Interfaces;

namespace ProvaConceito.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService) : base()
        {
            _vendaService = vendaService;
        }

        [Route("IncluirVenda")]
        [HttpPost]
        public async Task<OutParameterBase> IncluirVenda(VendaModel dados)
        {
            OutParameterBase outParameterBase = new OutParameterBase();

            if (!dados.Itens.Any())
            {
                outParameterBase.CodRetorno = -1;
                outParameterBase.MsgRetorno = "Informe ao menos um item";
            }
            else
            {
                outParameterBase.CodRetorno = await _vendaService.IncluirVenda(dados);
            }

            return outParameterBase;
        }

        [Route("BuscarVenda/{id:int}")]
        [HttpGet]
        public async Task<VendaModel> BuscarVenda(int id)
        {
            return await _vendaService.BuscarVenda(id);
        }

        [Route("AtualizarStatus")]
        [HttpPost]
        public async Task<OutParameterBase> AtualizarStatusVenda(int idPedido, StatusVenda status)
        {
            return await _vendaService.AtualizarStatusVenda(idPedido, status);
        }
    }
}
