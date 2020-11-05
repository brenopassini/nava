using ProvaConceito.Domain.Enum;
using ProvaConceito.Domain.Models;
using ProvaConceito.Domain.Models.OutParameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProvaConceito.Domain.Services.Interfaces
{
    public interface IVendaService : IDisposable
    {
        Task<int> IncluirVenda(VendaModel dados);

        Task<VendaModel> BuscarVenda(int id);
        Task<OutParameterBase> AtualizarStatusVenda(int idPedido, StatusVenda status);
    }
}
