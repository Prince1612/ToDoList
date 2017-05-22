using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DataModel.Models;

namespace TodoList.DataModel.Services
{
    public interface INotesService
    {
        IEnumerable<Note> GetAllNotes();

        Task<bool> AddNotesAsync(Note note);

        Task<bool> DeleteNotesAsync(Guid id);

        Task<bool> UpdateNotesAsync(Note note);
    }
}