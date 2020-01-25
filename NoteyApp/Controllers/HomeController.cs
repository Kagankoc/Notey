using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoteyApp.Models;
using NoteyApp.Repositories;
using System;
using System.Diagnostics;
using System.Linq;

namespace NoteyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoteRepository _noteRepository;

        public HomeController(ILogger<HomeController> logger, INoteRepository noteRepository)
        {
            _logger = logger;
            _noteRepository = noteRepository;
        }

        public IActionResult Index()
        {
            var notes = _noteRepository.GetAllNotes().Where(n => n.IsDeleted == false);

            return View();
        }

        public IActionResult NoteDetail(Guid id)
        {
            var note = _noteRepository.FindNoteById(id);
            return View(note);
        }

        [HttpGet]
        public IActionResult NoteEditor(Guid id = default) //TODO Connect to EntityFrameWork
        {
            if (id != Guid.Empty)
            {
                var note = _noteRepository.FindNoteById(id);
                return View(note);

            }

            return View();
        }

        [HttpPost]
        public IActionResult NoteEditor(NoteModel noteModel) //TODO Connect to EntityFrameWork
        {
            var date = DateTime.Now;
            if (noteModel == null)
            {
                return BadRequest();
            }

            if (noteModel.NoteId == Guid.Empty)
            {
                noteModel.NoteId = Guid.NewGuid();
                noteModel.CreatedDate = date;
                noteModel.LastModifiedDate = date;

                _noteRepository.SaveNote(noteModel);
            }
            else
            {
                var note = _noteRepository.FindNoteById(noteModel.NoteId);
                note.LastModifiedDate = date;
                note.Subject = noteModel.Subject;
                note.Detail = noteModel.Detail;

            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteNote(Guid id)  //TODO Connect to EntityFrameWork
        {
            var note = _noteRepository.FindNoteById(id);
            note.IsDeleted = true;

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
