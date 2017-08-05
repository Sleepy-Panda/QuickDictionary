using Microsoft.AspNetCore.Mvc;
using QuickDictionary.Common.Entities;
using QuickDictionary.Services;
using QuickDictionary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickDictionary.Web.Controllers
{
    public class TranslationController : Controller
    {
        private readonly TranslationService _translationService;
        private readonly DictionaryService _dictionaryService;
        private readonly LanguageService _languageService;

        public TranslationController(
            TranslationService translationService,
            DictionaryService dictionaryService,
            LanguageService languageService)
        {
            _translationService = translationService;
            _dictionaryService = dictionaryService;
            _languageService = languageService;
        }

        /// <summary>
        /// Gets all translations for selected dictionary.
        /// </summary>
        /// <param name="id">Dictionary Id.</param>
        [HttpGet]
        public IActionResult Index(int id)
        {
            var translations = _translationService
                .GetSourcePhrasesByDictionaryId(id)
                .Select(d => new TranslationIndexViewModel
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

        /// <summary>
        /// Renders page to add translation to selected dictionary.
        /// </summary>
        /// <param name="id">Dictionary Id.</param>
        [HttpGet]
        public IActionResult Create(int id)
        {
            var dictionary = _dictionaryService.GetDictionaryById(id);

            if (dictionary == null)
            {
                return View();
            }

            var sourceLanguage = _languageService.GetLanguageById(dictionary.SourceLanguageId);
            var targetLanguage = _languageService.GetLanguageById(dictionary.TargetLanguageId);

            var model = new TranslationCreateViewModel {
                DictionaryId = dictionary.Id,
                DictionaryName = dictionary.Name,
                DictionaryDescription = dictionary.Description ?? String.Empty,
                SourceLanguageName = sourceLanguage?.Name ?? String.Empty,
                TargetLanguageName = targetLanguage?.Name ?? String.Empty,
                SourceLanguageCode = sourceLanguage?.Code ?? String.Empty,
                TargetLanguageCode= targetLanguage?.Code ?? String.Empty,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SourcePhrase sourcePhrase, List<string> translations)
        {
            return View();
        }
    }
}