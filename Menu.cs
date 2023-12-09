/***********************
Name: Steven Drew
Date: 11/25/2023
Assignment: CIS317 Project - Game Score Tracking Application

The Menu class is used to display a menu to the user and get input
from the user. Methods are provided to display the menu, get the
user's choice.
*/

public class Menu
{
    // Method to display the menu to the user
    public void DisplayMenu()
    {
        Console.WriteLine("\nGame Score Tracking Menu (Enter Corresponding Number/Letter):" +
            "\n\t1. Add Game" +
            "\n\t2. Remove Game" +
            "\n\t3. Add Score" +
            "\n\t4. Remove Score" +
            "\n\t5. Display Scores" +
            "\n\t6. Display Games" +
            "\n\t7. Calculate Performance" +
            "\n\tQ. Quit");
    }

    // Method to get the user's choice from the menu
    public string GetInput()
    {
        // Get input from the user
        string? input = Console.ReadLine();

        // While the input is null or empty, prompt the user for valid input till
        // the while loop condition is false
        while (string.IsNullOrEmpty(input))
        {
            Console.Write("\nPlease enter a valid input: ");
            input = Console.ReadLine();
        }

        // Return the input to where the method was called
        return input;
    }
}