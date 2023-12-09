/************************
Name: Steven Drew
Date: 11/25/2023
Assignment: CIS317 Project - Game Score Tracking Application

Main application class
*/

// Import the SQLite library
using System.Data.SQLite;

public class Project
{
    static void Main(string[] args)
    {
        const string dbName = "GameScoreTrack.db";
        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);
        GameScoreTrackDB.CreateGameTable(conn);
        GameScoreTrackDB.CreateScoreTable(conn);
        gameScoreTrackApp.Start();
    }
}