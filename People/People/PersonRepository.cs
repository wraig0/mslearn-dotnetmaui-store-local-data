﻿using Microsoft.Extensions.Logging;
using People.Models;
using SQLite;

namespace People;

public class PersonRepository
{
    string _dbPath;

    public string StatusMessage { get; set; }

    private SQLiteConnection conn;

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Person>();
    }

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;                        
    }

    public void AddNewPerson(string name)
    {            
        int result = 0;
        try
        {
            Init();

            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            result = conn.Insert(new Person { Name = name });
            

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }

        if (result != 0)
        {
            // deal with it
        }
    }

    public List<Person> GetAllPeople()
    {
        List<Person> people = new List<Person>();
        try
        {
            Init();
            return conn.Table<Person>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return people;
    }
}
