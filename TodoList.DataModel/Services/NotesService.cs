using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DataModel.Context;
using TodoList.DataModel.Models;

namespace TodoList.DataModel.Services
{
    public class NotesService : INotesService
    {
        TodoListContext _context;
        public NotesService(TodoListContext context)
        {
            _context = context;
        }
        public async Task<bool> AddNotesAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            return (await _context.SaveChangesAsync()) == 1;
        }

        public async Task<bool> DeleteNotesAsync(Guid id)
        {
            var note = _context.Notes.FirstOrDefault(x => x.Id == id);
            _context.Notes.Remove(note);
            return (await _context.SaveChangesAsync()) == 1;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _context.Notes;
        }

        public async Task<bool> UpdateNotesAsync(Note note)
        {
            var noteToBeUpdated = _context.Notes.FirstOrDefault(x => x.Id == note.Id);
            if (noteToBeUpdated == null)
                return false;

            noteToBeUpdated.Title = note.Title;
            noteToBeUpdated.Message = note.Message;
            noteToBeUpdated.LastModified = note.LastModified;
            
            return (await _context.SaveChangesAsync()) == 1;
        }
    }
}
