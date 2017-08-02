using System;

namespace QuickDictionary.Web.Models
{
    public class DictionaryViewModel
    {
        public int Id { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
