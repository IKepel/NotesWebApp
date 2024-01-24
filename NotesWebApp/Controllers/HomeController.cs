using Contracts;
using Microsoft.AspNetCore.Mvc;
using NotesProcessor;
using NotesWebApp.Models;
using System.Diagnostics;

namespace NotesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotesConverter _notesConverter;

        public HomeController(INotesConverter notesConverter)
        {
            _notesConverter = notesConverter;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNode(Note note) 
        {
            if (ModelState.IsValid)
            {
                _notesConverter.AddNote(note);
            }
            return View("Index");
        }

        public IActionResult AllMyNotes()
        {
            var allNotes = _notesConverter.GetAllNotes();
            return View(allNotes);
        }

        [HttpPost]
        public IActionResult DeleteNode(Guid id)
        {
            _notesConverter.DeleteNote(id);
            var allNotes = _notesConverter.GetAllNotes();
            return View("AllMyNotes", allNotes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
