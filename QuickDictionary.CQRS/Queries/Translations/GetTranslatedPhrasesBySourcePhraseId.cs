using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;
using System.Collections.Generic;
using System.Linq;

namespace QuickDictionary.CQRS.Queries.Translations
{
    public class GetTranslatedPhrasesBySourcePhraseId : IQuery<IList<TranslatedPhrase>>
    {
        private readonly int _id;

        public GetTranslatedPhrasesBySourcePhraseId(int id)
        {
            _id = id;
        }

        public IList<TranslatedPhrase> Execute(ISession session)
        {
            return session
                .Query<TranslatedPhrase>(
                    "SELECT * " +
                    "FROM TranslatedPhrases " +
                    "WHERE SourcePhraseId = @Id " +
                    "ORDER BY Value ASC", new { Id = _id })
                .ToList();
        }
    }
}
