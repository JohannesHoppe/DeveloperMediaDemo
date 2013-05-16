using Mongo2Go;
using WebNoteSinglePage.Models;

namespace WebNoteSinglePage.AppStart
{
    public class MongoDbConfig
    {
        private MongoDbRunner _runner;

        public static string ConnectionString { get; private set; }
        public const string DatabaseName = "WebNote";

        public void Start()
        {
            _runner = MongoDbRunner.StartForDebugging();
            _runner.Import(DatabaseName, MongoDbNoteRepository.CollectionNotes, @"..\App_Data\" + MongoDbNoteRepository.CollectionNotes + ".json", true);
            _runner.Import(DatabaseName, MongoDbNoteRepository.CollectionCategories, @"..\App_Data\" + MongoDbNoteRepository.CollectionCategories + ".json", true);

            ConnectionString = _runner.ConnectionString;
        }

        public void Stop()
        {
            if (_runner != null && !_runner.Disposed) {
                _runner.Dispose();
            }
        }
    }
}