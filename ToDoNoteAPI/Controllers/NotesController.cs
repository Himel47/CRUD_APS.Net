using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoNoteAPI.Data;
using ToDoNoteAPI.Models;

namespace ToDoNoteAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly dbConnection connection;

        public NotesController(dbConnection connection)
        {
            this.connection = connection;
        }

        [HttpGet]
        public List<Note>GetAll()
        {
            var notes = connection.Notes.ToList();
            return notes;
        }

        [HttpGet("Id")]
        public Note GetNotebyId(int Id)
        {
            var noteById = connection.Notes.Where(x => x.Id == Id).SingleOrDefault();
            if(noteById != null)
            {
                return noteById;
            }
            return null;
        }

        [HttpPost]
        public Note AddNote(Note note)
        {
            connection.Notes.Add(note);
            if(connection.SaveChanges()>0) {
                return note;
            }
            return null;
        }

    }
}
