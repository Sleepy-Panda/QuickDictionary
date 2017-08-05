using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;

namespace QuickDictionary.CQRS.Commands.Translations
{
    public class CreateTranslatedPhrase : ICommand
    {
        private readonly TranslatedPhrase _translatedPhrase;

        public CreateTranslatedPhrase(TranslatedPhrase translatedPhrase)
        {
            _translatedPhrase = translatedPhrase;
        }

        public void Execute(ISession session)
        {
            session.Execute(
                "INSERT INTO TranslatedPhrases (DictionaryId, Value, CreatedAt) " +
                "VALUES (@DictionaryId, @Value, @CreatedAt)", 
                new { _translatedPhrase.SourcePhraseId, _translatedPhrase.Value });
        }
    }
}
