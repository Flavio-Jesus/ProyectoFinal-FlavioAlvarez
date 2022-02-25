using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_FlavioAlvarez.Models
{
    public class DatosSimulacion
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "canDiasProduccionSemanal")]
        public int canDiasProduccionSemanal { get; set; }

        [JsonProperty(PropertyName = "canHorasProduccionDiarias")]
        public int canHorasProduccionDiarias { get; set; }

        [JsonProperty(PropertyName = "canMes")]
        public int canMes { get; set; }

        [JsonProperty(PropertyName = "canDias")]
        public int canDias { get; set; }

        [JsonProperty(PropertyName = "canHoras ")]
        public int canHoras { get; set; }

        [JsonProperty(PropertyName = "precioProducto")]
        public int precioProducto { get; set; }

        [JsonProperty(PropertyName = "maquina1")]
        public string maquina1 { get; set; }

        [JsonProperty(PropertyName = "maquina2")]
        public string maquina2 { get; set; }

        [JsonProperty(PropertyName = "producto")]
        public string producto { get; set; }

        [JsonProperty(PropertyName = "canProductosM1")]
        public int canProductosM1 { get; set; }

        [JsonProperty(PropertyName = "canProductosM2")]
        public int canProductosM2 { get; set; }

        [JsonProperty(PropertyName = "gananciaM1")]
        public int gananciaM1 { get; set; }

        [JsonProperty(PropertyName = "gananciaM2")]
        public int gananciaM2 { get; set; }

        [JsonProperty(PropertyName = "ganaciaRealM1")]
        public int ganaciaRealM1 { get; set; }

        [JsonProperty(PropertyName = "ganaciaRealM2")]
        public int ganaciaRealM2 { get; set; }

        [JsonProperty(PropertyName = "maquyinaRecomendad")]
        public string Maquina_Recomendada { get; set; }
    }
}
