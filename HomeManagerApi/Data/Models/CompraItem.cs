using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeManagerApi.Data.Models
{
    [Table("ComprasItem")]
    public class CompraItem
    {
        public Guid Id { get; set; }
        public Guid CompraId { get; set; }
        public Compra Compra { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
    }
}
