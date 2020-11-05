using ProvaConceito.Domain.Enum;
using ProvaConceito.Domain.Models;
using ProvaConceito.Domain.Models.OutParameters;
using ProvaConceito.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProvaConceito.Domain.Interfaces
{
    public interface IVendaRepository : IAsyncRepository<VendaModel>
    {
        Task<int> IncluirVenda(VendaModel dados);
        Task<VendaModel> BuscarVenda(int id);
        Task<OutParameterBase> AtualizarStatusVenda(int idPedido, StatusVenda status);
    }
}
