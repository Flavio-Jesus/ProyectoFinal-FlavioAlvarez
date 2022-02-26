using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_FlavioAlvarez.Models
{
    public class Maquina
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "cantProductHora")]
        public int cantProductHora { get; set; }

        [JsonProperty(PropertyName = "costoOperacionHora")]
        public int costoOperacionHora { get; set; }

        [JsonProperty(PropertyName = "probabilidadFallo")]
        public double probabilidadFallo { get; set; }

        [JsonProperty(PropertyName = "horasReparacion")]
        public double horasReparacion { get; set; }

        [JsonProperty(PropertyName = "fechaCompra")]
        public DateTime fechaCompra { get; set; }

        [JsonProperty(PropertyName = "estado")]
        public Boolean estado { get; set; }
    }
}
