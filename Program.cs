using System;

// Namespace
namespace Mathiplier
{
    // Main Class
    class Program
    {
        // Entry Point Method
        static void Main(string[] args)
        {
            OpeningCredits(); // Display date, writer and name of app

            int difficulty = 0;
            int finalScore = 0;
            bool running = true;
            bool correctAnswer = true;

            // Ask users name
            Console.WriteLine("Before we begin,");

            while (running == true)
            {
                Console.WriteLine("What is your math level? [LOW, MID or HIGH]");

                bool openQuestion1 = true;

                while (openQuestion1 == true)
                {
                    // Get user input
                    string gameLevel = Console.ReadLine().ToUpper();

                    Console.WriteLine("");

                    openQuestion1 = false;
                    correctAnswer = true;
                    finalScore = 0;

                    if (gameLevel == "LOW")
                    {
                        difficulty = 10;
                    }
                    else if (gameLevel == "MID")
                    {
                        difficulty = 100;
                    }
                    else if (gameLevel == "HIGH")
                    {
                        difficulty = 1000;
                    }
                    else
                    {
                        Console.WriteLine("Please type either LOW, MID or HIGH.");
                        openQuestion1 = true;
                    }
                }

                while (correctAnswer == true)
                {
                    Random value1 = new Random();

                    int num1 = value1.Next(1, difficulty);
                    int num2 = value1.Next(1, difficulty);

                    int correctNumber = num1 + num2;

                    bool pass = false;

                    // Ask user for number
                    Console.WriteLine("{0} + {1} = ", num1, num2);

                    int myGuess = 0;
                    string guess = "";

                    //Make sure the number passed is a number
                    while (!pass)
                    {
                        guess = Console.ReadLine();

                        if (!int.TryParse(guess, out myGuess))
                        {
                            // Print error message
                            WriteColoredLine(ConsoleColor.Yellow, "\nPlease enter a number!\n");
                            Console.WriteLine("{0} + {1} = ", num1, num2);
                        }
                        else
                        {
                            pass = true;
                        }
                    }

                    myGuess = Int32.Parse(guess);
                    Console.WriteLine("");

                    //If your guess is NOT correct
                    if (correctNumber != myGuess)
                    {
                        //assign correct answer to false
                        correctAnswer = false;

                        //award the score to the player after game over
                        if (finalScore == 0)
                        {
                            WriteColoredLine(ConsoleColor.Red, "Well.. That was awkward..");
                        }
                        else if (finalScore < 5)
                        {
                            WriteColoredLine(ConsoleColor.Red, "Not bad! You at least got {0} correct", finalScore);
                        }
                        else if (finalScore < 10)
                        {
                            WriteColoredLine(ConsoleColor.Red, "Great Job! You got {0} correct", finalScore);
                        }
                        else
                        {
                            WriteColoredLine(ConsoleColor.Red, "Awesome!!! You got {0} correct", finalScore);
                        }

                        //output the correct answer to the question
                        WriteColoredLine(ConsoleColor.Red, "The correct answer was {0}.", correctNumber);
                    }
                    else
                    {
                        //Correct answer
                        WriteColoredLine(ConsoleColor.Green, "CORRECT!! You guessed it!\n");

                        //Add one to the number of correct answers
                        finalScore++;
                    }
                }

                bool playAgain = false;

                while (!playAgain)
                {
                    // Ask to play again
                    Console.WriteLine("\nDo you want to play again? [Y or N]");

                    // Get answer
                    string answer = Console.ReadLine().ToUpper();
                    Console.WriteLine("");

                    if (answer == "Y")
                    {
                        playAgain = true;
                    }
                    else if (answer == "N")
                    {
                        return;
                    }
                    else
                    {
                        WriteColoredLine(ConsoleColor.Yellow, "Please type either Y or N.");
                    }
                }
            }
        }

        // Get and display app info
        static void OpeningCredits()
        {
            // Set app vars
            string gameTitle = "Mathiplier";
            string gameWriter = "Keith Mulqueen";
            string gameDate = "November 20th, 2017";

            // Change text color
            Console.ForegroundColor = ConsoleColor.White;

            // Write out app info
            Console.WriteLine("You are about to play {0}!", gameTitle);
            Console.WriteLine("This game was written on {0} by {1}\n", gameDate, gameWriter);

            // Reset text color
            Console.ResetColor();
        }

        static void WriteColoredLine(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void WriteColoredLine(ConsoleColor color, string message, int number1)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message, number1);
            Console.ResetColor();
        }

        static void WriteColoredLine(ConsoleColor color, string message, int number1, int number2)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message, number1, number2);
            Console.ResetColor();
        }
    }
}

