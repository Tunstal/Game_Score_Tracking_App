/***************************
Name: Steven Drew
Date: 11/25/2023
Assignment: CIS317 Project - Game Score Tracking Application

This is the base class of all of the classes.  It acts as the 
controller for the application and is used to instantiate
the necessary classes and call the necessary methods to run the
application.  The Start method is the method that is called to start
the application and uses a switch statement to determine which method
to call based on the user's input. The methods that are called are
used to add, remove, and display games and scores, as well as calculate
the performance of the user based on the average of scores.  They also
control what the output is to the user and controls the validation of
the user's input.
*/

public class gameScoreTrackApp
{
    // Instantiate the necessary classes for the application
    private static Menu menu = new Menu();
    private static Tracker tracker = new Tracker();
    private static PerformanceCalculator calc = new PerformanceCalculator(); 

    // Method to start the application
    public static void Start()
    {
        // While the application is running, display the menu and get the user's input
        // where the input is used to determine which method to call.
        // The methods called are used to add, remove, and display games and scores, along with
        // calculating the performance.  Q is used to quit the application.
        // There is validation on user input to ensure that the user enters a valid input and
        // if the option is available to the user.
        while (true)
        {
            menu.DisplayMenu();
            Console.Write("Please Enter Input: ");
            string input = menu.GetInput();
            switch (input)
            {
                case "1":
                    AddGame();
                    break;
                case "2":
                    if (tracker.GetGames().Count == 0)
                    {
                        Console.WriteLine("\nNo games to remove.");
                        break;
                    }
                    RemoveGame();
                    break;
                case "3":
                    if (tracker.GetGames().Count == 0)
                    {
                        Console.WriteLine("\nNo games to add a score to.");
                        break;
                    }
                    AddScore();
                    break;
                case "4":
                    if (tracker.GetGames().Count == 0)
                    {
                        Console.WriteLine("\nNo games to remove a score from.");
                        break;
                    }
                    RemoveScore();
                    break;
                case "5":
                    if (tracker.GetGames().Count == 0)
                    {
                        Console.WriteLine("\nNo games to display scores for.");
                        break;
                    }
                    DisplayScores();
                    break;
                case "6":
                    if (tracker.GetGames().Count == 0)
                    {
                        Console.WriteLine("\nNo games to display.");
                        break;
                    }
                    DisplayGames();
                    break;
                case "7":
                    if (tracker.GetGames().Count == 0)
                    {
                        Console.WriteLine("\nNo games to calculate performance for.");
                        break;
                    }
                    CalculatePerformance();
                    break;
                case "Q":
                    return;
                default:
                    Console.WriteLine("Invalid Input.");
                    break;
            }
        }
    }

    // Method to begin the adding game process
    private static void AddGame()
    {
        Console.Write("\nEnter name of game to add (Q to exit): ");
        string name = menu.GetInput();

        if (name == "Q")
        {
            return;
        }

        // Validate that the user entered a valid float value
        while (float.TryParse(name, out float num))
        {
            Console.Write("\nPlease enter a valid input: ");
            name = menu.GetInput();
        }
        
        // Add the game to the Tracker class AddGame() method with the name entered 
        tracker.AddGame(new Game(name));
    }

    // Method to begin the removing game process
    private static void RemoveGame()
    {
        // Display the games to the user
        DisplayGames();
        Console.Write("\nEnter corresponding number of game to remove (Q to exit): ");
        string input = menu.GetInput();

        if (input == "Q")
        {
            return;
        }

        // Validate that the user entered a valid int value and that the value is within the range of the list of games
        while (!int.TryParse(input, out int num) || num < 0 || num >= tracker.GetGames().Count)
        {
            Console.Write("\nPlease enter a valid input:");
            input = menu.GetInput();
        }

        // Remove the game from the Tracker class RemoveGame() method with the index entered
        int index = Convert.ToInt32(input);
        tracker.RemoveGame(index);
        Console.WriteLine("\nGame Removed.");
    }

    // Method to begin the adding score process
    private static void AddScore()
    {
        // Display the games to the user
        DisplayGames();
        Console.Write("\nEnter corresponding number of game to add a score to (Q to exit): ");
        string input = menu.GetInput();

        if (input == "Q")
        {
            return;
        }

        // Validate that the user entered a valid int value and that the value is within the range of the list of games
        while (!int.TryParse(input, out int num) || num < 0 || num >= tracker.GetGames().Count)
        {
            Console.Write("\nPlease enter a valid input:");
            input = menu.GetInput();
        }

        // Convert input to int and set the index to the value for the game to add a score to
        int index = Convert.ToInt32(input);
        Console.Write("\nEnter score to add: ");
        string score = menu.GetInput();

        // Validate that the user entered a valid float value
        while (!float.TryParse(score, out float num))
        {
            Console.Write("\nPlease enter a valid input:");
            score = menu.GetInput();
        }

        // Add the score to the Game class AddScore() method with the score entered
        // where it will obtain the game ID from the index and add the score to the
        // corresponding game
        float scoreNum = Convert.ToSingle(score);
        tracker.GetGames()[index].AddScore(scoreNum);
        Console.WriteLine("\nScore Added.");
    }

    // Method to begin the removing score process
    private static void RemoveScore()
    {
        // Display the games to the user
        DisplayGames();
        Console.Write("\nEnter corresponding number of game to remove a score from (Q to exit): ");
        string input = menu.GetInput();

        if (input == "Q")
        {
            return;
        }

        // Validate that the user entered a valid int value and that the value is within the range of the list of games
        while (!int.TryParse(input, out int num) || num < 0 || num >= tracker.GetGames().Count)
        {
            Console.Write("\nPlease enter a valid input:");
            input = menu.GetInput();
        }

        // Convert input to int and set the index to the value for the game to display scores
        int index = Convert.ToInt32(input);
        DisplayScores(index);
        Console.Write("\nEnter corresponding number of the score to remove: ");
        string score = menu.GetInput();

        // Validate that the user entered a valid int value and that the value is within the range of the list of scores
        while (!int.TryParse(score, out int num) || num < 0 || num >= tracker.GetGames()[index].GetScores().Count)
        {
            Console.Write("\nPlease enter a valid input:");
            score = menu.GetInput();
        }

        // Remove the score from the Game class RemoveScore() method with the index entered
        // where it will obtain the game ID from the index and remove the score from the
        // corresponding game
        int scoreNum = Convert.ToInt32(score);
        tracker.GetGames()[index].RemoveScore(scoreNum);
        Console.WriteLine("\nScore Removed.");
    }

    // First method to display scores to the user by getting the index of the game to display scores for
    private static void DisplayScores()
    {
        // Display the games to the user
        DisplayGames();
        Console.Write("\nEnter corresponding number of game to display scores: ");
        string input = menu.GetInput();

        if (input == "Q")
        {
            return;
        }

        // Validate that the user entered a valid int value and that the value is within the range of the list of games
        while (!int.TryParse(input, out int num) || num < 0 || num >= tracker.GetGames().Count)
        {
            Console.Write("\nPlease enter a valid input:");
            input = menu.GetInput();
        }

        int index = Convert.ToInt32(input);
        DisplayScores(index);
    }

    // Second method to display scores to from the first method with the provided index
    private static void DisplayScores(int index)
    {
        // Create a list of scores from the Game class GetScores() method with the index entered
        // where it will obtain the game ID from the index and get the scores from the
        // corresponding game
        List<float> scores = tracker.GetGames()[index].GetScores();
        Console.WriteLine("\nScores:");

        // Loop through the list of scores and display them to the user
        foreach (float score in scores)
        {
            Console.WriteLine("{0}: {1}", scores.IndexOf(score), score);
        }
    }

    // Method to display games to the user
    private static void DisplayGames()
    {
        // Create a list of games from the Tracker class GetGames() method
        Console.WriteLine("\nGames:");
        List<Game> games = tracker.GetGames();

        // Loop through the list of games and display them to the user
        foreach (Game game in games)
        {
            Console.WriteLine("{0}: {1}", games.IndexOf(game), game.Name);
        }
        
    }

    // Method to begin the calculating performance process
    private static void CalculatePerformance()
    {
        // Display the games to the user
        DisplayGames();
        Console.Write("\nEnter corresponding number of game to calculate score average: ");
        string input = menu.GetInput();

        if (input == "Q")
        {
            return;
        }

        // Validate that the user entered a valid int value and that the value is within the range of the list of games
        while (!int.TryParse(input, out int num) || num < 0 || num >= tracker.GetGames().Count)
        {
            Console.Write("\nPlease enter a valid input:");
            input = menu.GetInput();
        }

        // Convert input to int and set the index to the value for the game to calculate performance for
        // Then create a list of scores from the Game class GetScores() method with the index entered.
        // where it will obtain the game ID from the index and get the scores from the corresponding game.
        // Then call the PerformanceCalculator class CalculatePerformance() method with the list of scores
        // to calculate the performance and display it to the user.
        int index = Convert.ToInt32(input);
        List<float> scores = tracker.GetGames()[index].GetScores();
        float performance = calc.CalculatePerformance(scores);
        Console.WriteLine($"{tracker.GetGames()[index].Name} Performance: {performance:F2}");
    }
}