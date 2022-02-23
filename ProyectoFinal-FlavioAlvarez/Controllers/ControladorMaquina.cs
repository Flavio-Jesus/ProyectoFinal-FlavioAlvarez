using ProyectoFinal_FlavioAlvarez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_FlavioAlvarez.Controllers
{
    public class ControladorMaquina : Controller
    {
        private readonly ICosmosDBService<Maquina> _cosmosDBService;

        public MaquinaController(ICosmosDBService<Maquina> cosmosDBService)
        {
            this._cosmosDBService = cosmosDBService;
        }

        public async Task<List<Maquina>> Index()
        {
            return (await this._cosmosDBService.GetItemsAsync("SELECT * FROM maquina")).ToList();
        }

        public async Task AddItem()
        {
            Maquina maquina = new Maquina();
            maquina.id = Guid.NewGuid().ToString();

            await this._cosmosDBService.AddItemAsync(maquina, maquina.id);
        }

        public async Task UpdateItem(string id)
        {
            Maquina maquina = new Maquina();
            maquina.id = id;

            await this._cosmosDBService.UpdateItemAsync(id, maquina);
        }

        public async Task DeleteItem(string id)
        {
            await this._cosmosDBService.DeleteItemAsync(id);
        }
    }
}
