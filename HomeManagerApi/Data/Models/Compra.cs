using System;
using System.Collections.Generic;

namespace HomeManagerApi.Data.Models
{
    public class Compra
    {
        public Guid Id { get; set; }
        public DateTime IncluidoDataHora { get; set; }
        public DateTime UltimaAlteracaoDataHora { get; set; } = DateTime.Now;
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public bool Concluido { get; set; }
        public List<CompraItem> Itens { get; set; }
    }
}
