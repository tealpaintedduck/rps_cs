using System;

namespace RockPaperScissors
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			Console.WriteLine ("Welcome to RockPaperScissors!");
			chooseGameType ();
		}

		public static void chooseGameType() {
			Console.WriteLine ("Enter '1' for P v Computer, or '2' for Computer v Computer");
			var gameType = Console.ReadLine ();
			if (Convert.ToInt32(gameType) == 1)
				startOnePlayerGame ();
			else
				startComputerGame ();
		}

		public static void startOnePlayerGame()
		{
			Console.WriteLine ("Enter your name:");
			var player = new Player (Console.ReadLine ());
			var computerPlayer = new Player ();
			var game = new Game (player, computerPlayer);
			Console.WriteLine ("Choose rock, paper or scissors");
			game.playerOne.throwGesture(Console.ReadLine ());
			Console.WriteLine (game.playerOne.name + " chooses " + game.playerOne.gesture);
			playerTurn (game.playerTwo);
			revealWinner (game);
			playAgain ();
		}

		public static void startComputerGame()
		{
			var computerPlayerOne = new Player ("COMPUTER REGGIE");
			var computerPlayerTwo = new Player ("COMPUTER BERNARD");
			var game = new Game (computerPlayerOne, computerPlayerTwo);
			game.playerOne.throwGesture();
			playerTurn (game.playerOne);
			playerTurn (game.playerTwo);
			revealWinner (game);
			playAgain ();
		}

		public static void playerTurn(Player player)
		{
			player.throwGesture();
			Console.WriteLine (player.name + " chooses " + player.gesture);
		}

		public static void revealWinner(Game game)
		{
			var winner = game.getWinner();
			if (winner == 1)
				Console.WriteLine (game.playerOne.name + " wins!");
			else if (winner == 2)
				Console.WriteLine (game.playerTwo.name + " wins!");
			else
				Console.WriteLine ("It's a draw!");
		}

		public static void playAgain() {
			Console.WriteLine ("Press 'gg' to go again or 'x' to exit");
			if (Console.ReadLine () == "gg")
				chooseGameType ();
			else
				Environment.Exit (2);
		}
	}
}
