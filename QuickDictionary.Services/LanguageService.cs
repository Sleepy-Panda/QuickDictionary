using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;
using QuickDictionary.CQRS.Queries.Languages;

namespace QuickDictionary.Services
{
    public class LanguageService
    {
        private readonly IDatabase _database;

        public LanguageService(IDatabase database)
        {
            _database = database;
        }

        public Language GetLanguageById(int id)
        {
            return _database.Query(new GetLanguageById(id));
        }
    }
}
