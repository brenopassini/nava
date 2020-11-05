using ProvaConceito.Domain.Enum;
using ProvaConceito.Domain.Interfaces;
using ProvaConceito.Domain.Models;
using ProvaConceito.Domain.Models.OutParameters;
using ProvaConceito.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProvaConceito.Domain.Services
{
    public class VendaService : IVendaService
    {
        public readonly  IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<int> IncluirVenda(VendaModel dados)
        {
            return await _vendaRepository.IncluirVenda(dados);
        }

        public async Task<VendaModel> BuscarVenda(int id)
        {
            return await _vendaRepository.BuscarVenda(id);
        }

        public async Task<OutParameterBase> AtualizarStatusVenda(int idPedido, StatusVenda status)
        {
            return await _vendaRepository.AtualizarStatusVenda(idPedido, status);
        }

        public void Dispose()
        {
            _vendaRepository?.Dispose();
        }
    }
}
