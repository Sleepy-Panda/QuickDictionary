using System.ComponentModel.DataAnnotations;

namespace QuickDictionary.Web.Models
{
    public class TranslationCreateViewModel
    {
        public int DictionaryId { get; set; }

        public string DictionaryName { get; set; }

        public string DictionaryDescription { get; set; }

        public string SourceLanguageName { get; set; }

        public string SourceLanguageCode { get; set; }

        public string TargetLanguageName { get; set; }

        public string TargetLanguageCode { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Put word or phrase to translate")]
        public string Value { get; set; }
    }
}
