using Journal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Services
{
    public class NoteService
    {
        private readonly JournalDatabase _db;
        private static readonly object _dbLock = new object();

        public NoteService(JournalDatabase db)
        {
            _db = db;
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return Task.FromResult(_db.Database.Table<Note>().ToList());
        }

        public Task AddNoteAsync(Note note)
        {
            lock (_dbLock)
            {
                _db.Database.Insert(note);
            }
            return Task.CompletedTask;
        }

        public Task UpdateNoteAsync(Note note)
        {
            lock (_dbLock)
            {
                _db.Database.Update(note);
            }
            return Task.CompletedTask;
        }

        public Task DeleteNoteAsync(Note note)
        {
            lock (_dbLock)
            {
                _db.Database.Delete(note);
            }
            return Task.CompletedTask;
        }



    }
}
