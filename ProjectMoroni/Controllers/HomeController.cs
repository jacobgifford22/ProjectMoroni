using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectMoroni.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMoroni.Controllers
{
    public class HomeController : Controller
    {
        private ScriptureNoteContext _repo { get; set; }

        // Constructor
        public HomeController(ScriptureNoteContext repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Background()
        {
            return View();
        }

        public IActionResult Notebook()
        {
            var scriptureNotes = _repo.ScriptureNotes
                .Include(x => x.Category)
                .OrderBy(x => x.CategoryId)
                .OrderBy(x => x.Reference)
                .ToList();

            return View(scriptureNotes);
        }

        public IActionResult Details(int scriptureNoteId)
        {
            ViewBag.Categories = _repo.Categories.ToList();

            var scriptureNote = _repo.ScriptureNotes.Single(x => x.ScriptureNoteId == scriptureNoteId);

            return View(scriptureNote);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _repo.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(ScriptureNote sn)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(sn);
                _repo.SaveChanges();

                return RedirectToAction("Notebook");
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList();

                return View(sn);
            }
        }

        [HttpGet]
        public IActionResult Edit(int scriptureNoteId)
        {
            ViewBag.Categories = _repo.Categories.ToList();

            var scriptureNote = _repo.ScriptureNotes.Single(x => x.ScriptureNoteId == scriptureNoteId);

            return View("Create", scriptureNote);
        }

        [HttpPost]
        public IActionResult Edit(ScriptureNote sn)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(sn);
                _repo.SaveChanges();

                return RedirectToAction("Notebook");
            }
            else
            {
                return RedirectToAction("Edit", new { ScriptureNoteId = sn.ScriptureNoteId });
            }
        }

        [HttpGet]
        public IActionResult Delete(int ScriptureNoteId)
        {
            var scriptureNote = _repo.ScriptureNotes.Single(x => x.ScriptureNoteId == ScriptureNoteId);

            return View(scriptureNote);
        }

        [HttpPost]
        public IActionResult Delete(ScriptureNote sn)
        {
            _repo.ScriptureNotes.Remove(sn);
            _repo.SaveChanges();

            return RedirectToAction("Notebook");
        }

    }
}
