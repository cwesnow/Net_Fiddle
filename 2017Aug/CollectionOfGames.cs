using System;

public class Program
{
	public static void Main()
	{
		// Loop until user doesn't want to play anymore
		while (true)
		{
			GamesList.selectGame();
			if (!newGame())
				break;
		}

		Console.WriteLine("Thanks for playing, Good bye!");
	}

	// Returns T/F if a user wants another game	
	static bool newGame()
	{
		Console.WriteLine("\n\nPlay another game?");
		return Console.ReadLine().ToUpper() == "Y" ? true : false;
	}
}

// Shared base class, so I can have an array of common objects with a common method
public abstract class Game
{
	public String Title = "title";
	public abstract void Start();
}

// Game 1 - Inherit from Game for shared attributes and behavior
public class NumberGuess : Game
{
	// Constructor uses base to set inherited attributes
	public NumberGuess()
	{
		base.Title = "Number Guess";
	}

	// Rewriting the Start() method for our custom classes needs
	public override void Start()
	{
		int tries = 3, guessed = -1;
		int correct = new Random().Next(0, 10);
		Console.WriteLine("Welcome to Number Guess! {0}", correct);
		for (int i = tries; tries > 0; tries--)
		{
			Console.Write("{0} guesses left\nNext Guess: ", tries);
			while (!int.TryParse(Console.ReadLine(), out guessed))
			{
				Console.WriteLine("Invalid Number! Try again");
			}

			if (guessed == correct)
			{
				Console.WriteLine("You Win!");
				break;
			}
			else if (guessed < correct)
			{
				Console.WriteLine("You guessed too low!");
			}
			else
			{
				Console.WriteLine("You guessed too high!");
			}
		}
	}
}

// Game 2
public class TicTacToe : Game
{
	public TicTacToe()
	{
		base.Title = "Tic Tac Toe";
	}

	public override void Start()
	{
		Console.WriteLine("Start a game of Tic Tac Toe");
	}
}

// Game 3
public class Hangman : Game
{
	public Hangman()
	{
		base.Title = "Hangman";
	}

	public override void Start()
	{
		Console.WriteLine("Start a game of Hangman");
	}
}

// Stores every Game, Displays them, and let's user play one
public class GamesList
{
	static Game[] games = {new NumberGuess(), new TicTacToe(), new Hangman()};
	// Displays Games Array starting at 1 for Users
	static void displayGames()
	{
		for (int i = 0; i < games.Length; i++)
		{
			Console.WriteLine("{0,2}. {1}", i, games[i].Title);
		}
	}

	// Gets User input, Checks that it's a number, number is below number of games and above 0
	static int chooseGame()
	{
		int x = 0;
		while (!int.TryParse(Console.ReadLine(), out x) || x >= games.Length || x < 0)
		{
			Console.WriteLine("Invalid Number!");
		}

		return x;
	}

	// Combines Menu Display with Picking Game and Playing it
	public static void selectGame()
	{
		Console.WriteLine("Select a Game:");
		displayGames();
		games[chooseGame()].Start();
	}
}
