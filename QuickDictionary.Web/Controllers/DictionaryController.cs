using Microsoft.AspNetCore.Mvc;
using QuickDictionary.Services;
using QuickDictionary.Web.Models;
using System;
using System.Linq;

namespace QuickDictionary.Web.Controllers
{
    public class DictionaryController : Controller
    {
        private DictionaryService _dictionaryService;
        private LanguageService _languageService;

        public DictionaryController(
            DictionaryService dictionaryService,
            LanguageService languageService)
        {
            _dictionaryService = dictionaryService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var list = _dictionaryService
                .GetAllDictionaries()
                .Select(d => new DictionaryViewModel {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    CreatedAt = d.CreatedAt,
                    UpdatedAt = d.UpdatedAt,
                    SourceLanguage = _languageService
                        .GetLanguageById(d.SourceLanguageId)?.Name ?? String.Empty,
                    TargetLanguage = _languageService
                        .GetLanguageById(d.TargetLanguageId)?.Name ?? String.Empty,
                })
                .ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DictionaryViewModel model)
        {
            return View();
        }
    }
}