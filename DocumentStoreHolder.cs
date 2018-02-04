using Microsoft.Extensions.Configuration;
using System;
using Raven.Client.Documents;
using System.IO;

namespace TotalFusionApi
{
    public class DocumentStoreHolder

    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {
            var Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            String url = Configuration["Raven:Url"];
            String database = Configuration["Raven:Database"];

            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { url },
                Database = database
            }.Initialize();

            return store;
        }
    }
}