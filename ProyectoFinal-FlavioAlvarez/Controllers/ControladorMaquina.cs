using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_FlavioAlvarez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_FlavioAlvarez.Controllers
{
    public class ControladorMaquina : Controller
    {
        private readonly ICosmosDBServiceMaquina _cosmosDBService;

        public ControladorMaquina(ICosmosDBServiceMaquina cosmosDBService)
        {
            this._cosmosDBService = cosmosDBService;
        }

        public async Task<ActionResult> Maquina()
        {
            return View((await this._cosmosDBService.GetMaquinasAsync("SELECT * FROM maquina")).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> CrearMaquina(Maquina maquina)
        {
            maquina.id = Guid.NewGuid().ToString();
            await this._cosmosDBService.AddMaquinaAsync(maquina);
            return RedirectToAction("Maquina");
        }
        public IActionResult Edit(Maquina Maquina)
        {
            return View(Maquina);
        }

        public async Task<ActionResult> EditMaquina(Maquina maquina)
        {
            await this._cosmosDBService.UpdateMaquinaAsync(maquina.id, maquina);
            return RedirectToAction("Maquina");
        }
        public ActionResult Delete(Maquina maquina)
        {
            return View(maquina);
        }

        public async Task<ActionResult> DeleteMaquina(Maquina maquina)
        {
            await _cosmosDBService.DeleteMaquinaAsync(maquina.id);
            return RedirectToAction("Maquina");
        }
    }
}
