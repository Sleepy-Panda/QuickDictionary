using QuickDictionary.Contracts.Entities;

namespace QuickDictionary.Common.Entities
{
    public class TranslatedPhrase : IEntity
    {
        public int Id { get; set; }

        public int SourcePhraseId { get; set; }

        public string Value { get; set; }
    }
}
