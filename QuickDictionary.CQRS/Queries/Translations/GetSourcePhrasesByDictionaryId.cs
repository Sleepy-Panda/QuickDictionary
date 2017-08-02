using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;
using System.Collections.Generic;
using System.Linq;

namespace QuickDictionary.CQRS.Queries.Translations
{
    public class GetSourcePhrasesByDictionaryId : IQuery<IList<SourcePhrase>>
    {
        private readonly int _id;

        public GetSourcePhrasesByDictionaryId(int id)
        {
            _id = id;
        }

        public IList<SourcePhrase> Execute(ISession session)
        {
            return session
                .Query<SourcePhrase>(
                    "SELECT * " +
                    "FROM SourcePhrases " +
                    "WHERE Id = @Id " +
                    "ORDER BY CreatedAt DESC", new { Id = _id })
                .ToList();
        }
    }
}
