/******************************
Name: Steven Drew
Date: 11/25/2023
Assignment: CIS317 Project - Game Score Tracking Application

The Tracker class is used to create a list of the games so that
they can be tracked. Methods provided are to add and remove games
as well as get the list of games.
*/

// Import the SQLite library
using System.Data.SQLite;

public class Tracker
{
    // Database connection
    const string dbName = "GameScoreTrack.db";
    SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

    // Method to add a game to the database
    public void AddGame(Game game)
    {
        GameScoreTrackDB.InsertGame(conn, game.Name);
    }

    // Method to remove a game from the database
    public void RemoveGame(int index)
    {
        List<Game> games = GameScoreTrackDB.GetAllGames(conn);
        Game gameToRemove = games[index];
        GameScoreTrackDB.DeleteGame(conn, gameToRemove.ID);
    }

    // Method to get all games from the database in the form of a list of Game objects
    public List<Game> GetGames()
    {
        return GameScoreTrackDB.GetAllGames(conn);
    }
}