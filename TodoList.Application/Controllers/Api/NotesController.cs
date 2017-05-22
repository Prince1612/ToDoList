using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Application.Models;
using TodoList.DataModel.Models;
using TodoList.DataModel.Services;

namespace TodoList.Application.Controllers.Api
{
    [Authorize(Roles ="admin")]
    [Route("/api/[controller]")]
    public class NotesController : Controller
    {
        private readonly INotesService _notesService;
        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNotesAsync()
        {
            var notes = await Task.Run(() => { return _notesService.GetAllNotes(); });
            return Ok(notes);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotes([FromBody] Note note)
        {
            if (note == null || !ModelState.IsValid)
                return BadRequest();

            var result = await _notesService.UpdateNotesAsync(note);
            if (result)
                return NoContent();
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] NoteViewModel noteViewModel)
        {
            if (noteViewModel == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Note note = new Note
            {
                Id = Guid.NewGuid(),
                Title = noteViewModel.Title,
                Message = noteViewModel.Message,
                DateCreated = noteViewModel.DateCreated,
                LastModified = noteViewModel.LastModified
            };

            bool isSuccess = await _notesService.AddNotesAsync(note);
            if (isSuccess)
                return Created(string.Empty, null);
            else
                return new ObjectResult("Failed to create notes");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            bool isSuccess = await _notesService.DeleteNotesAsync(id);
            if (isSuccess)
                return NoContent();
            else
                return BadRequest();
        }
    }
}
