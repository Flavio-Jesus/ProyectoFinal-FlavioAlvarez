using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_FlavioAlvarez.Models
{

    public interface ICosmosDBServiceSimulacion
    {
        Task<IEnumerable<DatosSimulacion>> GetSimulatioAsync(string query);
        Task AddSimulationtoAsync(DatosSimulacion item);
    }
    public class CosmosDBServiceSimulacion : ICosmosDBServiceSimulacion
    {
        private Container _container;

        public CosmosDBServiceSimulacion(CosmosClient client, string databaseName, string containerName)
        {
            this._container = client.GetContainer(databaseName, containerName);
        }
        public async Task AddSimulationtoAsync(DatosSimulacion item)
        {
            await this._container.CreateItemAsync<DatosSimulacion>(item, new PartitionKey(item.id));
        }

        public async Task<IEnumerable<DatosSimulacion>> GetSimulatioAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<DatosSimulacion>(new QueryDefinition(queryString));
            List<DatosSimulacion> results = new List<DatosSimulacion>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
    }
}
