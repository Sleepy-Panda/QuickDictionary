using QuickDictionary.Contracts.Entities;
using System;

namespace QuickDictionary.Common.Entities
{
    public class Dictionary : ILoggedEntity
    {
        public int Id { get; set; }

        public int SourceLanguageId { get; set; }

        public int TargetLanguageId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
