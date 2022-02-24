using Microsoft.Azure.Cosmos;

namespace ProyectoFinal_FlavioAlvarez
{
    public class CosmosDBService
    {
        private CosmosClient client;
        private string databaseName;
        private string containerName;

        public CosmosDBService(CosmosClient client, string databaseName, string containerName)
        {
            this.client = client;
            this.databaseName = databaseName;
            this.containerName = containerName;
        }
    }
}