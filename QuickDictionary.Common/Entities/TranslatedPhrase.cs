using QuickDictionary.Contracts.Entities;
using System;

namespace QuickDictionary.Common.Entities
{
    public class TranslatedPhrase : ILoggedEntity
    {
        public int Id { get; set; }

        public int SourcePhraseId { get; set; }

        public string Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
