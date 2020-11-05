using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConceito.Domain.Models.OutParameters
{
    public class OutParameterBase
    {
        public string MsgRetorno { get; set; }
        public int CodRetorno { get; set; }
        public List<string> ListMensagens { get; set; }
    }
}
