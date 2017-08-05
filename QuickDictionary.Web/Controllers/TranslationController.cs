using Microsoft.AspNetCore.Mvc;
using QuickDictionary.Common.Entities;
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

        /// <summary>
        /// Gets all translations for selected dictionary.
        /// </summary>
        /// <param name="id">Dictionary Id.</param>
        public IActionResult Index(int id)
        {
            var translations = _translationService
                .GetSourcePhrasesByDictionaryId(id)
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

        public IActionResult Create()
        {
            var sourcePhraseId = _translationService.CreateSourcePhrase(new SourcePhrase { DictionaryId = 1, Value = "nowadays", CreatedAt = DateTime.Now });

            return null;
        }
    }
}