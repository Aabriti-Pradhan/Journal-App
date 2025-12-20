using Journal.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Journal.Services
{
    public class JournalDatabase
    {
        private readonly SQLiteConnection _db;

        public JournalDatabase()
        {
            var dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "journal.db"
            );

            Console.WriteLine(dbPath);

            _db = new SQLiteConnection(dbPath);

            _db.CreateTable<User>();
            _db.CreateTable<Note>();
        }

        public SQLiteConnection Database => _db;
    }
}
