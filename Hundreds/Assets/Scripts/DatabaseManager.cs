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
            @"DROP TABLE IF EXISTS highscores_endless;
            CREATE TABLE IF NOT EXISTS highscores_endless (
                id INTEGER PRIMARY KEY,
                name TEXT(3),
                score INT,
                timestamp DATE DEFAULT (datetime('now','localtime')));
            DROP TABLE IF EXISTS highscores_coop;
            CREATE TABLE IF NOT EXISTS highscores_coop (
                id INTEGER PRIMARY KEY,
                name TEXT(3),
                score INT,
                timestamp DATE DEFAULT (datetime('now','localtime')));
            INSERT INTO highscores_endless (name, score) VALUES ('AAA', 41);
            INSERT INTO highscores_endless (name, score) VALUES ('AAB', 875);
            INSERT INTO highscores_endless (name, score) VALUES ('AFA', 975);
            INSERT INTO highscores_endless (name, score) VALUES ('HAA', 12);
            INSERT INTO highscores_endless (name, score) VALUES ('APA', 981);
            INSERT INTO highscores_endless (name, score) VALUES ('OQE', 100);
            INSERT INTO highscores_endless (name, score) VALUES ('FAW', 9);
            INSERT INTO highscores_endless (name, score) VALUES ('VMD', 13);
            INSERT INTO highscores_endless (name, score) VALUES ('VZQ', 71);
            INSERT INTO highscores_coop (name, score) VALUES ('POY', 14);
            INSERT INTO highscores_coop (name, score) VALUES ('PVD', 429);
            INSERT INTO highscores_coop (name, score) VALUES ('MFZ', 138);
            INSERT INTO highscores_coop (name, score) VALUES ('QQP', 86);
            INSERT INTO highscores_coop (name, score) VALUES ('ZZZ', 129);
            INSERT INTO highscores_coop (name, score) VALUES ('LPR', 91);
            INSERT INTO highscores_coop (name, score) VALUES ('UEI', 651);
            INSERT INTO highscores_coop (name, score) VALUES ('ALR', 47);
            INSERT INTO highscores_coop (name, score) VALUES ('BNI', 222);
            ";
            
		command.ExecuteNonQuery();
        command.CommandText = ""; // Clear command

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

    public List<HighscoreEntry> GetEndless()
    {
        command.CommandText = 
            @"SELECT * FROM highscores_endless
            ORDER BY score DESC
            LIMIT 10;";
        reader = command.ExecuteReader();
        List<HighscoreEntry> highscoreList = new List<HighscoreEntry>();
        while (reader.Read())
        {
            HighscoreEntry entry = new HighscoreEntry(System.Convert.ToInt32(reader[2]), reader[1].ToString());
            highscoreList.Add(entry);
        }

        reader.Close();
        command.CommandText = "";

        return highscoreList;
    }

    public List<HighscoreEntry> GetCoop()
    {
        command.CommandText = 
            @"SELECT * FROM highscores_coop
            ORDER BY score DESC
            LIMIT 10;";
        reader = command.ExecuteReader();
        List<HighscoreEntry> highscoreList = new List<HighscoreEntry>();
        while (reader.Read())
        {
            HighscoreEntry entry = new HighscoreEntry(System.Convert.ToInt32(reader[2]), reader[1].ToString());
            highscoreList.Add(entry);
        }

        reader.Close();
        command.CommandText = "";

        return highscoreList;
    }

    void OnDisable()
    {
        dbcon.Close();
    }

}
