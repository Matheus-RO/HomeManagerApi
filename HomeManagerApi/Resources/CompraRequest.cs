using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagerApi.Resources
{
    public class CompraRequest
    {
        //public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public bool Concluido { get; set; }
        //public List<CompraItem> Itens { get; set; }
    }
}
