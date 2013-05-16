using Microsoft.Practices.Unity;
using MongoDB.Driver;
using WebNoteSinglePage.Models;

namespace WebNoteSinglePage.AppStart
{
    public static class UnityContainerConfig
    {
        public static IUnityContainer RegisterTypes()
        {
            MongoServer server = new MongoClient(MongoDbConfig.ConnectionString).GetServer();
            MongoDatabase database = server.GetDatabase(MongoDbConfig.DatabaseName);
                                              
            IUnityContainer container = new UnityContainer();

            container.RegisterInstance(database);
            container.RegisterType<INoteRepository, MongoDbNoteRepository>();
            
            return container;
        }
    }
}