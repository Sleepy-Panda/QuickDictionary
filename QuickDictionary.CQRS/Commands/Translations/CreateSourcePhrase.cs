using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;

namespace QuickDictionary.CQRS.Commands.Translations
{
    public class CreateSourcePhrase : ICommand<int>
    {
        private readonly SourcePhrase _sourcePhrase;

        public CreateSourcePhrase(SourcePhrase sourcePhrase)
        {
            _sourcePhrase = sourcePhrase;
        }

        /// <summary>
        /// Inserts new source phrase and returns its Id.
        /// </summary>
        public int Execute(ISession session)
        {
            return session.ExecuteScalar<int>(
                "INSERT INTO SourcePhrases (DictionaryId, Value, CreatedAt) " +
                "VALUES (@DictionaryId, @Value, @CreatedAt); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT)", 
                new { _sourcePhrase.DictionaryId, _sourcePhrase.Value, _sourcePhrase.CreatedAt });
        }
    }
}
