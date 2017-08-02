using QuickDictionary.Contracts.Entities;
using System;

namespace QuickDictionary.Common.Entities
{
    public class SourcePhrase : ILoggedEntity
    {
        public int Id { get; set; }

        public int DictionaryId { get; set; }

        public string Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
