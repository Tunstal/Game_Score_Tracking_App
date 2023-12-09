/******************************
Name: Steven Drew
Date: 11/25/2023
Assignment: CIS317 Project - Game Score Tracking Application

PerformanceCalculator is the class that is used to calculate the
performance based on the average scores that they entered for a game.
*/

public class PerformanceCalculator
{
    // Method to calculate the performance based on the average scores
    public float CalculatePerformance(List<float> scores)
    {
        // If there are scores in the list, calculate the average
        // else return 0
        if (scores.Count > 0)
        {
            return scores.Average();
        }
        else
        {
            return 0;
        }
    }
}