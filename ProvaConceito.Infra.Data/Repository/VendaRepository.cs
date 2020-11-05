using AspnetCore_EFCoreInMemory.Models;
using Microsoft.EntityFrameworkCore;
using ProvaConceito.Domain.Enum;
using ProvaConceito.Domain.Interfaces;
using ProvaConceito.Domain.Models;
using ProvaConceito.Domain.Models.OutParameters;
using Suporte.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaConceito.Infra.Data.Repository
{
    public class VendaRepository : BaseRepository<VendaModel>, IVendaRepository
    {
        public VendaRepository(SqlServerDbContext db) : base(db)
        {
        }

        public async Task<int> IncluirVenda(VendaModel dados)
        {
            Db.Venda.Add(dados);
            return await Db.SaveChangesAsync();
        }

        public async Task<VendaModel> BuscarVenda(int id)
        {
            return await Db.Venda.Where(o => o.IdPedido == id)
                        .Include(v => v.Vendedor)
                        .Include(i => i.Itens)
                        .FirstOrDefaultAsync();
        }

        public async Task<OutParameterBase> AtualizarStatusVenda(int idPedido, StatusVenda status)
        {
            OutParameterBase outParameterBase = new OutParameterBase();

            var venda = await Db.Venda.FirstOrDefaultAsync(o => o.IdPedido == idPedido);

            switch (venda.Status)
            {
                case StatusVenda.AguardandoPagamento:
                    if (status != StatusVenda.Cancelada && status != StatusVenda.PagamentoAprovado)
                    {
                        outParameterBase.CodRetorno = -1;
                        outParameterBase.MsgRetorno = "Status inválido";
                    }
                    break;
                case StatusVenda.PagamentoAprovado:
                    if (status != StatusVenda.Cancelada && status != StatusVenda.EnviadoTransportadora)
                    {
                        outParameterBase.CodRetorno = -1;
                        outParameterBase.MsgRetorno = "Status inválido";
                    }
                    break;
                case StatusVenda.EnviadoTransportadora:
                    if (status != StatusVenda.Entregue)
                    {
                        outParameterBase.CodRetorno = -1;
                        outParameterBase.MsgRetorno = "Status inválido";
                    }
                    break;
            }

            if (outParameterBase.CodRetorno != -1)
            {
                venda.Status = status;
                Db.Update(venda);
                Db.SaveChanges();
                outParameterBase.CodRetorno = 0;
                outParameterBase.MsgRetorno = "Status alterado";
            }

            return outParameterBase;
        }
    }
}
