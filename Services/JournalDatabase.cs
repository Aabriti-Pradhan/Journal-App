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
    internal class JournalDatabase
    {
        private readonly SQLiteConnection _db;

        public JournalDatabase()
        {
            var dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "journal.db"
            );

            _db = new SQLiteConnection(dbPath);

            _db.CreateTable<User>();
        }

        public SQLiteConnection Database => _db;
    }
}
