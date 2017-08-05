using System;
using System.Collections.Generic;

namespace QuickDictionary.Web.Models
{
    public class TranslationIndexViewModel
    {
        public int Id { get; set; }

        public int DictionaryId { get; set; }

        public string Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public IEnumerable<string> TranslatedValues { get; set; }

        public TranslationIndexViewModel()
        {
            TranslatedValues = new List<string>();
        }
    }
}
