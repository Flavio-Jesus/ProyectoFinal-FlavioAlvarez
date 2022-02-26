using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_FlavioAlvarez.Models
{
    public class DatosSimulacion
    {
        public DatosSimulacion()
        {
            maquina1 = "";
            maquina2 = "";
            producto = "";
            maquyinaRecomendad = "";
            id = "";
            ganaciaRealM2 = 0;
            ganaciaRealM1 = 0;
            gananciaM2 = 0;
            gananciaM1 = 0;
            canProductosM2 = 0;
            canProductosM1 = 0;
            precioProducto = 0;
            canHorasProduccionDiarias = 0;
            canDiasProduccionSemanal = 0;
            canMes = 0;
            canDias = 0;
            canHoras = 0;
        }
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "canHora")]
        public int canHoras { get; set; }

        [JsonProperty(PropertyName = "canDias")]
        public int canDias { get; set; }

        [JsonProperty(PropertyName = "canMes")]
        public int canMes { get; set; }

        [JsonProperty(PropertyName = "canDiasProduccionSemanal")]
        public int canDiasProduccionSemanal { get; set; }

        [JsonProperty(PropertyName = "canHorasProduccionDiarias")]
        public int canHorasProduccionDiarias { get; set; }

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
        public string maquyinaRecomendad { get; set; }
    }
}
