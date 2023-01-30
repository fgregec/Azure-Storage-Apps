﻿using Microsoft.Azure.Cosmos;
using PersonNoSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PersonNoSQL.Dao
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container container;

        public CosmosDbService(CosmosClient client, string databaseName, string containerName)
        {
            container = client.GetContainer(databaseName, containerName);
        }

        public async Task AddPersonAsync(Person person)
        => await container.CreateItemAsync(person, new PartitionKey(person.Id));

        public async Task DeletePersonAsync(Person person)
        => await container.DeleteItemAsync<Person>(person.Id, new PartitionKey(person.Id));

        public async Task<IEnumerable<Person>> GetPeopleAsync(string queryString)
        {
            List<Person> people = new List<Person>();
            var query = container.GetItemQueryIterator<Person>(new QueryDefinition(queryString));

            while (query.HasMoreResults)
            {
                var result = await query.ReadNextAsync();
                people.AddRange(result.ToList());
            }

            return people;
        }

        public async Task<Person> GetPersonAsync(string id)
        {
            try
            {
                return await container.ReadItemAsync<Person>(id, new PartitionKey(id));
            }
            catch (CosmosException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdatePersonAsync(Person person)
        => await container.UpsertItemAsync(person, new PartitionKey(person.Id));
    }
}