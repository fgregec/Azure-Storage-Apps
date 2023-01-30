using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PersonNoSQL.Dao
{
    public class CosmosDbServiceProvider
    {
        private const string DatabaseName = "People";
        private const string ContainerName = "Person";
        private const string Account = "https://pppk2022.documents.azure.com:443/";
        private const string Key = "sZWqluUefjtabdxI0glOfawnfYtIkGa1DwtnUfiUwqoARaHmuHKcvi0Hm5b6kDRrbXzJCmRfT1fJACDb38eGiQ==";

        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService; }

        public static async Task Init()
        {
            CosmosClient cosmosClient = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(cosmosClient, DatabaseName, ContainerName);
            DatabaseResponse databaseResponse = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await databaseResponse.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }
    }
}