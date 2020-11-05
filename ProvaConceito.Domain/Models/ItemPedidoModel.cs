using ProvaConceito.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProvaConceito.Domain.Models
{
    public class ItemPedidoModel :  BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
