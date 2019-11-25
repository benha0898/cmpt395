using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    private IDbConnection dbcon;
    private IDbCommand command;
    private IDataReader reader;

    // Start is called before the first frame update
    void Start()
    {

        /// Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "Hundreds_Database";
		
		// Open connection
		dbcon = new SqliteConnection(connection);
		dbcon.Open();

        // Command variable
        command = dbcon.CreateCommand();

		// Create table
		command.CommandText =
            @"CREATE TABLE IF NOT EXISTS highscores_endless (
                id INTEGER PRIMARY KEY,
                name TEXT(3),
                score INT,
                timestamp DATE DEFAULT (datetime('now','localtime')));
            CREATE TABLE IF NOT EXISTS highscores_coop (
                id INTEGER PRIMARY KEY,
                name TEXT(3),
                score INT,
                timestamp DATE DEFAULT (datetime('now','localtime')));";
		command.ExecuteNonQuery();
        command.CommandText = ""; // Clear command

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

        command.CommandText = "SELECT date('now', 'localtime');";
        reader = command.ExecuteReader();
        while (reader.Read())
		{
			Debug.Log(reader[0].ToString());
        }
        reader.Close();
        command.CommandText = "";
    }

    public void InsertEndless(string name, int score)
    {
        command.CommandText = 
            @"INSERT INTO highscores_endless (name, score) VALUES ('"
            + name + "', " + score.ToString() + ");";
        Debug.Log(command.CommandText);
        command.ExecuteNonQuery();
        command.CommandText = "";
    }

    public void InsertCoop(string name, int score)
    {
        command.CommandText = 
            @"INSERT INTO highscores_coop (name, score) VALUES ('"
            + name + "', " + score.ToString() + ");";
        Debug.Log(command.CommandText);
        command.ExecuteNonQuery();
        command.CommandText = "";
    }

    void OnDisable()
    {
        dbcon.Close();
    }

}
