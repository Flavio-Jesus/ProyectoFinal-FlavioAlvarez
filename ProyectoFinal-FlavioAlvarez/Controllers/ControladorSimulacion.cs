using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_FlavioAlvarez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_FlavioAlvarez.Controllers
{
    public class ControladorSimulacion : Controller
    {
        private readonly ICosmosDBServiceMaquina _cosmosDBServiceMaquina;
        private readonly ICosmosDBServiceProducto _cosmosDBServiceProducto;
        private readonly ICosmosDBServiceSimulacion _cosmosDBServiceSimulacion;

        public ControladorSimulacion(ICosmosDBServiceMaquina cosmosDBServiceMaquina, ICosmosDBServiceProducto cosmosDBServiceProducto, ICosmosDBServiceSimulacion cosmosDBServiceSimulacion)
        {
            this._cosmosDBServiceMaquina = cosmosDBServiceMaquina;
            this._cosmosDBServiceProducto = cosmosDBServiceProducto;
            this._cosmosDBServiceSimulacion = cosmosDBServiceSimulacion;
        }
        // GET: ControladorSimulacion
        public ActionResult Simulacion()
        {
            IEnumerable<DatosSimulacion> simulacion = this._cosmosDBServiceSimulacion.GetSimulatioAsync("SELECT * FROM datossimulacion").Result;
            var simulacionResult = simulacion.ToList().Last();
            return View(simulacionResult);

        }
        public async Task<ActionResult> SimulacionList()
        {
            return View((await this._cosmosDBServiceSimulacion.GetSimulatioAsync("SELECT * FROM datossimulacion")).ToList());
        }

        public IActionResult Create()
        {
            IEnumerable<Maquina> maquinas = this._cosmosDBServiceMaquina.GetMaquinasAsync("SELECT * FROM maquina").Result;
            VistaSimulacion model = new VistaSimulacion();
            model.maquina = maquinas;

            IEnumerable<Producto> productos = this._cosmosDBServiceProducto.GetProductosAsync("SELECT * FROM producto").Result;
            model.producto = productos;

            return View(model);
        }

        public async Task<ActionResult> CreateSimulacion(VistaSimulacion modelo)
        {
            Maquina maquina1 = this._cosmosDBServiceMaquina.GetMaquinaAsync(modelo.simulacion.maquina1).Result;
            Maquina maquina2 = this._cosmosDBServiceMaquina.GetMaquinaAsync(modelo.simulacion.maquina2).Result;
            Producto producto = this._cosmosDBServiceProducto.GetProductoAsync(modelo.simulacion.producto).Result;
            modelo.simulacion.id = Guid.NewGuid().ToString();
            int totalHorasTrabajadas = 0;
            int totalDias = modelo.simulacion.canMes * 28;
            totalDias += modelo.simulacion.canDias;
            int totalHoras = modelo.simulacion.canHoras;
            int diasNoLaborados = 7 - modelo.simulacion.canDiasProduccionSemanal;
            int contDias = 1;
            int contHoras = 1;
            for (int i = 0; i <= totalDias; i++)
            {
                totalHoras = 24;
                if (contDias <= modelo.simulacion.canDiasProduccionSemanal)
                {
                    for (int j = 1; j <= totalHoras; j++)
                    {
                        if (contHoras <= modelo.simulacion.canHorasProduccionDiarias)
                        {
                            totalHorasTrabajadas++;
                            contHoras++;
                        }
                        else
                        {
                            totalHoras = 0;
                            contHoras = 1;
                            contDias++;
                        }
                    }
                }
                else
                {
                    i += diasNoLaborados;
                    contDias = 1;
                }
            }

            if (modelo.simulacion.canHoras <= modelo.simulacion.canHorasProduccionDiarias)
            {
                totalHorasTrabajadas += modelo.simulacion.canHoras;
            }
            else
            {
                totalHorasTrabajadas += modelo.simulacion.canHorasProduccionDiarias;
            }
            int restaMaquina1 = maquina1.costoOperacionHora * totalHorasTrabajadas;
            int restaMaquina2 = maquina2.costoOperacionHora * totalHorasTrabajadas;
            modelo.simulacion.canProductosM1 = maquina1.cantProductHora * totalHorasTrabajadas;
            modelo.simulacion.canProductosM2 = maquina2.cantProductHora * totalHorasTrabajadas;
            modelo.simulacion.gananciaM1 = (modelo.simulacion.canProductosM1 * producto.precio);
            modelo.simulacion.gananciaM2 = (modelo.simulacion.canProductosM2 * producto.precio);
            modelo.simulacion.ganaciaRealM1 = ((modelo.simulacion.gananciaM1 - (modelo.simulacion.canProductosM1 * modelo.simulacion.precioProducto)))-restaMaquina1;
            modelo.simulacion.ganaciaRealM2 = ((modelo.simulacion.gananciaM2 - (modelo.simulacion.canProductosM2 * modelo.simulacion.precioProducto)))-restaMaquina2;
            modelo.simulacion.maquyinaRecomendad = modelo.simulacion.ganaciaRealM1 > modelo.simulacion.ganaciaRealM2 ? maquina1.id : maquina2.id;
            await this._cosmosDBServiceSimulacion.AddSimulationtoAsync(modelo.simulacion);
            return RedirectToAction("Simulacion");

        }


    }
}
