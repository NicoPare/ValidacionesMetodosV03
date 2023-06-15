using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacionesMetodosV03.Entidades;

namespace ValidacionesMetodosV03.Entidades
{
    public class Vuelo
    {
        public string CodVuelo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Aerolinea { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public DateTime FechaHoraArribo { get; set; }
        public string TiempoDeVuelo { get; set; }
        public List<Tarifa> Tarifa { get; set; }
    }
}
