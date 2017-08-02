using Microsoft.AspNetCore.Mvc;
using QuickDictionary.Services;
using QuickDictionary.Web.Models;
using System.Linq;

namespace QuickDictionary.Web.Controllers
{
    public class DictionaryController : Controller
    {
        private DictionaryService _dictionaryService;

        public DictionaryController(DictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        public IActionResult Index()
        {
            var list = _dictionaryService
                .GetAllDictionaries()
                .Select(d => new DictionaryViewModel {
                    Id = d.Id,
                    Name = d.Name
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