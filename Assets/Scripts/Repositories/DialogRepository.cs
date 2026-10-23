using System.Collections.Generic;
using System.IO;
using SQLite;
using UnityEngine;

public class DialogRepository
{
    private readonly SQLiteConnection _database;

    public DialogRepository()
    {
        string databasePath = Path.Combine(
        Application.persistentDataPath,
        "dialogs.db"
        );

        _database = new SQLiteConnection(databasePath);
        _database.CreateTable<DialogEntry>();
    }

    public List<DialogEntry> GetAll()
    {
        return _database.Table<DialogEntry>().ToList();
    }

    public void Add(DialogEntry entry)
    {
        _database.Insert(entry);
    }

    public void Update(DialogEntry entry)
    {
        _database.Update(entry);
    }

    
    public void Delete(DialogEntry entry)
    {
        _database.Delete(entry);
    }
}