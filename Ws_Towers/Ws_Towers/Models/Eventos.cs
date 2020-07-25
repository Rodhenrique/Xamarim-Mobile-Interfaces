using System;
using System.Collections.Generic;
using System.Text;

namespace Ws_Towers.Models
{
    public class Eventos
    {
        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public int IdTimeVisitante { get; set; }
        public int IdTimeCasa { get; set; }
        public int IdEstadio { get; set; }
        public string Campeonato { get; set; }
        public string Detalhes { get; set; }
    }
}
