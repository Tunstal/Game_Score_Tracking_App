/*******************************
Name: Steven Drew
Date: 12/1/2023
Assignment: CIS317 Project - Game Score Tracking Application

This class handles interactions with the Game and Score tables in the database.
*/

// Import the SQLite library
using System.Data.SQLite;

public class GameScoreTrackDB
{
    // Method to create the Game table in the database
    // if it does not already exist
    public static void CreateGameTable(SQLiteConnection conn)
    {
        string sql = 
            "CREATE TABLE IF NOT EXISTS Game (\n"
            + "   GameID INTEGER PRIMARY KEY AUTOINCREMENT\n"
            + "   ,GameName TEXT NOT NULL UNIQUE);";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    // Method to create the Score table in the database
    // if it does not already exist
    public static void CreateScoreTable(SQLiteConnection conn)
    {
        string sql = 
            "CREATE TABLE IF NOT EXISTS Score (\n"
            + "   ScoreID INTEGER PRIMARY KEY AUTOINCREMENT\n"
            + "   ,GameID INTEGER NOT NULL\n"
            + "   ,Score INTEGER NOT NULL\n"
            + "   ,FOREIGN KEY (GameID) REFERENCES Game(GameID));";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    // Method to insert a game into the database
    public static void InsertGame(SQLiteConnection conn, string gameName)
    {
        string sql = "INSERT INTO Game (GameName) VALUES (@GameName);";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@GameName", gameName);
        cmd.ExecuteNonQuery();
    }

    // Method to insert a score into the database
    public static void InsertScore(SQLiteConnection conn, int gameID, float score)
    {
        string sql = "INSERT INTO Score (GameID, Score) VALUES (@GameID, @Score);";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@GameID", gameID);
        cmd.Parameters.AddWithValue("@Score", score);
        cmd.ExecuteNonQuery();
    }

    // Method to delete a game from the database
    public static void DeleteGame(SQLiteConnection conn, int gameID)
    {
        string sql = "DELETE FROM Game WHERE GameID = @GameID;";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@GameID", gameID);
        cmd.ExecuteNonQuery();
    }

    // Method to delete a score from the database
    public static void DeleteScore(SQLiteConnection conn, int scoreID)
    {
        string sql = "DELETE FROM Score WHERE ScoreID = @ScoreID;";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@ScoreID", scoreID);
        cmd.ExecuteNonQuery();
    }

    // Method to get all the games from the database
    public static List<Game> GetAllGames(SQLiteConnection conn)
    {
        List<Game> games = new List<Game>();
        string sql = "SELECT * FROM Game;";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader reader = cmd.ExecuteReader();

        // Loop through the game table and add the games to a list
        while (reader.Read())
        {
            games.Add(new Game(
                reader.GetInt32(0),
                reader.GetString(1)
            ));
        }

        // return the list to where the method was called
        return games;
    }

    // Method to get all the scores for a game from the database
    public static List<float> GetAllScores(SQLiteConnection conn, int gameID)
    {
        List<float> scores = new List<float>();
        string sql = "SELECT * FROM Score WHERE GameID = @GameID;";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@GameID", gameID);

        SQLiteDataReader reader = cmd.ExecuteReader();

        // Loop through the score table and add the scores to a list
        while (reader.Read())
        {
            scores.Add(reader.GetFloat(2));
        }

        return scores;
    }

    // Method to get all the score IDs for a game from the database
    public static List<int> GetAllScoreIds(SQLiteConnection conn, int gameID)
    {
        List<int> scoreIds = new List<int>();
        string sql = "SELECT ScoreID FROM Score WHERE GameID = @GameID;";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@GameID", gameID);

        SQLiteDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            scoreIds.Add(reader.GetInt32(0));
        }

        return scoreIds;
    }
}