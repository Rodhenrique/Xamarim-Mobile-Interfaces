using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class CompraIngressos
    {
        public int Id { get; set; }
        public int? Quantidade { get; set; }
        public string Valor { get; set; }
        public int? IdJogos { get; set; }
        public int? IdFormaDePagamento { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTipoDeIngresso { get; set; }
        public int? IdJogo { get; set; }

        public virtual FormaDePagamento IdFormaDePagamentoNavigation { get; set; }
        public virtual Jogos IdJogoNavigation { get; set; }
        public virtual Jogos IdJogosNavigation { get; set; }
        public virtual TipoDeIngresso IdTipoDeIngressoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
