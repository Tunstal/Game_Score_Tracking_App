/*****************************
Name: Steven Drew
Date: 12/1/2023
Assignment: CIS317 Project - Game Score Tracking Application

This class handles the interactions to the SQLite database.
*/

// Import the SQLite library
using System.Data.SQLite;

public class SQLiteDatabase
{
    // Method to establish a connection to the database
    public static SQLiteConnection Connect(string database)
    {
        string cs = @"Data Source=" + database;
        SQLiteConnection conn = new SQLiteConnection(cs);

        try
        {
            conn.Open();
        }
        catch (SQLiteException e)
        {
            Console.WriteLine(e.Message);
        }

        return conn;
    }
}