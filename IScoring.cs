/****************************
Name: Steven Drew
Date: 11/25/2023
Assignment: CIS317 Project - Game Score Tracking Application

This is the IScoring interface class that implements the methods
for the Game class will be required to implement to track scores
for each game.
*/

public interface IScoring
{
    // Provides template for methods that will be required to be implemented
    // for classes that implement this interface
    void AddScore(float score);
    void RemoveScore(int index);
}