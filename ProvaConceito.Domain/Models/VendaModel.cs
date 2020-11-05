using ProvaConceito.Domain.Enum;
using ProvaConceito.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProvaConceito.Domain.Models
{
    public class VendaModel :  BaseEntity
    {
        [Key]
        public int IdPedido { get; set; }
        public VendedorModel Vendedor { get; set; }
        public DateTime DataVenda { get; set; }
        public List<ItemPedidoModel> Itens { get; set; }
        public StatusVenda Status { get; set; }
    }
}
