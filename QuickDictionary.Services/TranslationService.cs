using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;
using QuickDictionary.CQRS.Queries.Translations;
using System.Collections.Generic;

namespace QuickDictionary.Services
{
    public class TranslationService
    {
        private readonly IDatabase _database;

        public TranslationService(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<SourcePhrase> GetSourcePhrasesByDictionaryId(int id)
        {
            return _database.Query(new GetSourcePhrasesByDictionaryId(id));
        }

        public IEnumerable<TranslatedPhrase> GetTranslatedPhrasesBySourcePhraseId(int id)
        {
            return _database.Query(new GetTranslatedPhrasesBySourcePhraseId(id));
        }
    }
}
