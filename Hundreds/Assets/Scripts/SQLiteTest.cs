using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SQLiteTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        /// Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "Hundreds_Database";
		
		// Open connection
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();

        // Command and reader variables
        IDbCommand command = dbcon.CreateCommand();
        IDataReader reader;

		// Create table
		command.CommandText =
            @"DROP TABLE IF EXISTS highscores_endless;
            CREATE TABLE IF NOT EXISTS highscores_endless (
                id INTEGER PRIMARY KEY,
                name TEXT(10),
                score INT,
                date DATE);";
		command.ExecuteNonQuery();
        command.CommandText = ""; // Clear command

		// Insert values in table
		command.CommandText =
            @"INSERT INTO highscores_endless VALUES (1, 'Ben', 110, NULL);
            INSERT INTO highscores_endless VALUES (2, 'Adam', 220, NULL);
            INSERT INTO highscores_endless VALUES (3, 'Cooper', 330, NULL);
            INSERT INTO highscores_endless VALUES (4, 'Wamaitha', 440, NULL);";
		command.ExecuteNonQuery();
        command.CommandText = "";

		// Read and print all values in table
		command.CommandText = "SELECT * FROM highscores_endless;";
		reader = command.ExecuteReader();
		while (reader.Read())
		{
			Debug.Log("id: " + reader[0].ToString()
                + ", name: " + reader[1].ToString()
                + ", score: " + reader[2].ToString()
                + ", date: " + reader[3].ToString());
		}
        reader.Close();
        command.CommandText = "";

		// Close connection
		dbcon.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
