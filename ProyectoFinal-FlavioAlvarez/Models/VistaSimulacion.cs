using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_FlavioAlvarez.Models
{
    public class VistaSimulacion
    {
        public DatosSimulacion simulacion { get; set; }
        public IEnumerable<Maquina> maquina { get; set; }
        public IEnumerable<Producto> producto { get; set; }
    }
}
