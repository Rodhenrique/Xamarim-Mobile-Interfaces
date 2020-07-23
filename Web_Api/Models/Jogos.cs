using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Jogos
    {
        public Jogos()
        {
            CompraIngressosIdJogoNavigation = new HashSet<CompraIngressos>();
            CompraIngressosIdJogosNavigation = new HashSet<CompraIngressos>();
        }

        public int Id { get; set; }
        public string Jogo { get; set; }
        public string Horario { get; set; }
        public DateTime Data { get; set; }
        public int? IdTimeVisitante { get; set; }
        public int? IdTimeCasa { get; set; }
        public int? IdEstadio { get; set; }
        public string Campeonato { get; set; }
        public string Endereço { get; set; }
        public string Detalhes { get; set; }

        public virtual Estadio IdEstadioNavigation { get; set; }
        public virtual Times IdTimeCasaNavigation { get; set; }
        public virtual Times IdTimeVisitanteNavigation { get; set; }
        public virtual ICollection<CompraIngressos> CompraIngressosIdJogoNavigation { get; set; }
        public virtual ICollection<CompraIngressos> CompraIngressosIdJogosNavigation { get; set; }
    }
}
