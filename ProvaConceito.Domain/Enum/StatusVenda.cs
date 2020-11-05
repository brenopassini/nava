using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConceito.Domain.Enum
{
    public enum StatusVenda
    {
        AguardandoPagamento = 0,
        PagamentoAprovado = 1,
        EnviadoTransportadora = 2,
        Entregue = 3,
        Cancelada = 4
    }
}
