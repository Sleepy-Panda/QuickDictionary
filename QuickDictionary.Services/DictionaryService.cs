using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;
using QuickDictionary.CQRS.Queries.Dictionaries;
using System.Collections.Generic;

namespace QuickDictionary.Services
{
    public class DictionaryService
    {
        private readonly IDatabase _database;

        public DictionaryService(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Dictionary> GetAllDictionaries()
        {
            return _database.Query(new GetAllDictionaries());
        }

        public void Save(Dictionary dictionary)
        {
            //_database.Execute(new CreateDictionary(dictionary));
        }
    }
}
