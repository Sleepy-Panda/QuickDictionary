using Microsoft.AspNetCore.Mvc;
using QuickDictionary.Services;
using QuickDictionary.Web.Models;
using System;
using System.Linq;

namespace QuickDictionary.Web.Controllers
{
    public class TranslationController : Controller
    {
        private TranslationService _translationService;

        public TranslationController(TranslationService translationService)
        {
            _translationService = translationService;
        }

        public IActionResult Index(int dictionaryId)
        {
            var translations = _translationService
                .GetSourcePhrasesByDictionaryId(dictionaryId)
                .Select(d => new TranslationViewModel
                {
                    Id = d.Id,
                    DictionaryId = d.DictionaryId,
                    Value = d.Value,
                    CreatedAt = d.CreatedAt,
                    UpdatedAt = d.UpdatedAt,           
                    TranslatedValues = _translationService
                        .GetTranslatedPhrasesBySourcePhraseId(d.Id)
                        .Select(t => t.Value ?? String.Empty)
                        .ToList(),
                })
                .ToList();

            return View(translations);
        }
    }
}