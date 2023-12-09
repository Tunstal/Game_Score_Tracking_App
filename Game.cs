/*********************
Name: Steven Drew
Date: 11/25/2023
Assignment: CIS317 Project - Game Score Tracking Application

The Game class implements the interface IScoring and is used to
track scores for each game that is instantiated.  It contains a
list of scores for each game and methods to add and remove scores
from the list.
*/

// Import the SQLite library
using System.Data.SQLite;

public class Game : IScoring
{
    // Properties for the Game class
    public int ID { get; set; }
    public string Name { get; set; }

    // Database connection
    const string dbName = "GameScoreTrack.db";
    SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

    // Constructor for the Game class
    public Game(int id, string name)
    {
        ID = id;
        Name = name;

    }

    // Overloaded constructor for the Game class that does not require an ID
    public Game(string name)
    {
        Name = name;
    }

    // Method to add a score to the database
    public void AddScore(float score)
    {
        GameScoreTrackDB.InsertScore(conn, ID, score);
    }

    // Method to remove a score from the database
    public void RemoveScore(int index)
    {
        List<int> scoreIDs = GameScoreTrackDB.GetAllScoreIds(conn, ID);
        int scoreIDToRemove = scoreIDs[index];
        GameScoreTrackDB.DeleteScore(conn, scoreIDToRemove);
    }

    // Method to get all scores for a game from the database
    public List<float> GetScores()
    {
        return GameScoreTrackDB.GetAllScores(conn, ID);
    }
}