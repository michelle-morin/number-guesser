using System;
using System.Collections.Generic;

public static class GuessGame
{
  static void Main()
  {
    Console.WriteLine("Would you like to play the higher/lower game? (Y/N)");
    string playGame = Console.ReadLine();
    string normalizedPlayGame = playGame.ToLower();
    if (normalizedPlayGame == "y") {
      Console.WriteLine("Think of a number between 1 and 100!");
      int[] inputAnswer = InitializeGame();
      CheckAnswer(inputAnswer);
    }
    else
    {
      Console.WriteLine("OK, have a nice day!");
    }
  }

  public static int[] InitializeGame()
  {
    Random rnd = new Random();
    int randomNumber = rnd.Next(1,100);
    Console.WriteLine("Is the number that you thought of higher or lower than " + randomNumber + " (Higher/Lower/Correct)");
    string userInput = Console.ReadLine();
    string normalizedUserInput = userInput.ToLower();
    int intUserInput = 0;
    if (normalizedUserInput == "correct")
    {
      intUserInput = 1;
    }
    else if (normalizedUserInput == "higher")
    {
      intUserInput = 2;
    }
    else if (normalizedUserInput == "lower")
    {
      intUserInput = 3;
    }
    else
    {
      Console.WriteLine("please enter higher, lower, or correct.");
      normalizedUserInput = Console.ReadLine();
    }
    int[] output = { intUserInput, 1, 100, randomNumber };
    return output;
  }

  public static void CheckAnswer(int[] answer)
  {
    if (answer[0] == 1)
    {
      Console.WriteLine("Great! I guessed your number.");
    }
    else if (answer[0] == 2)
    {
      int lowerBound = answer[3] + 1;
      int[] newAnswer = GuessAgain(lowerBound, answer[2]);
      CheckAnswer(newAnswer);
    }
    else if (answer[0] == 3)
    {
      int higherBound = answer[3] - 1;
      int[] newAnswer = GuessAgain(answer[1], higherBound);
      CheckAnswer(newAnswer); 
    }
  }

  public static int[] GuessAgain(int lowerNum, int higherNum)
  {
    Random rnd = new Random();
    int randomNumber = rnd.Next(lowerNum, higherNum);
    Console.WriteLine("Is the number that you thought of higher or lower than " + randomNumber + " (Higher/Lower/Correct)");
    string userInput = Console.ReadLine();
    string normalizedUserInput = userInput.ToLower();
    int intUserInput = 0;
    if (normalizedUserInput == "correct")
    {
      intUserInput = 1;
    }
    else if (normalizedUserInput == "higher")
    {
      intUserInput = 2;
    }
    else if (normalizedUserInput == "lower")
    {
      intUserInput = 3;
    }
    else
    {
      Console.WriteLine("please enter higher, lower, or correct.");
      normalizedUserInput = Console.ReadLine();
    }
    int[] output = { intUserInput, lowerNum, higherNum, randomNumber };
    return output;
  }
}