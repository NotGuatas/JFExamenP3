using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JFExamenP3.Models;
using System.Threading.Tasks;

namespace JFExamenP3;

public class JFClimaRepository
{
    string _dbPath;
    private SQLiteAsyncConnection conn;


    public string StatusMessage { get; set; }

    // TODO: Add variable for the SQLite connection

    private async Task Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteAsyncConnection(_dbPath);

        await conn.CreateTableAsync<JFInfoClima>();
    }

    public JFClimaRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public async Task AddNew(string main)
    {
        int result = 0;
        try
        {
            await Init();

            if (string.IsNullOrEmpty(main))
                throw new Exception("Valid name required");

            result = await conn.InsertAsync(new JFInfoClima { Name = main });

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, main);
            Console.WriteLine($"Ciudad guardada: {main}");  
        }
        catch (Exception ex)    
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", main, ex.Message);
        }
    }

    public async Task<List<JFInfoClima>> GetAllPeople()
    {
        try
        {
            await Init();
            var people = await conn.Table<JFInfoClima>().ToListAsync();
            Console.WriteLine($"Ciudades obtenidas: {people.Count}");  // Depuración

            return people;
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<JFInfoClima>();
    }
}
