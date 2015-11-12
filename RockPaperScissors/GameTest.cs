using NUnit.Framework;
using System;

[TestFixture]
public class GameTests

{

	class PlayerMock : Player
	{

		public string playerName;

		public PlayerMock (string name)
		{
			playerName = name;
		}

		public PlayerMock () {
			playerName = "COMPUTER";
		}

		public override void throwGesture() {
			gesture = "paper";

		}
	}


	Game game;
	Game computerGame;
	PlayerMock player;
	PlayerMock computerPlayer;
	PlayerMock computerPlayerTwo;

	[SetUp]
	public void GetReady()
	{
		player = new PlayerMock ("Ron");
		computerPlayer = new PlayerMock ();
		computerPlayerTwo = new PlayerMock ();
		game = new Game (player, computerPlayer);
		computerGame = new Game (computerPlayer, computerPlayerTwo);
	}



	[TearDown]
	public void Clean() {}


	[Test]
	public void HumanGameHasTwoPlayers()
	{
		Player[] result = {game.playerOne, game.playerTwo};
		Player[] expected = { player, computerPlayer };
		CollectionAssert.AreEqual (expected, result);
	}

	[Test]
	public void ComputerGameHasTwoPlayers()
	{
		Player[] result = {computerGame.playerOne, computerGame.playerTwo};
		Player[] expected = { computerPlayer, computerPlayerTwo };
		CollectionAssert.AreEqual (expected, result);
	}

	[Test]
	public void GameHasWinnerWhenPlayersHaveThrown ()
	{
		game.playerOne.throwGesture ("rock");
		game.playerTwo.throwGesture ();
		bool result = game.hasWinner ();
		Assert.AreEqual (true, result);
	}

	[Test]
	public void GameDoesNotHaveWinnerWhenPlayersHaveNotThrown()
	{
		game.playerOne.throwGesture ("rock");
		bool result = game.hasWinner ();
		Assert.AreEqual (false, result);	
	}

	[Test]
	public void GameKnowsWinner()
	{
		game.playerOne.throwGesture ("rock");
		game.playerTwo.throwGesture();
		int result = game.getWinner();
		Assert.AreEqual (2, result);
	}

	[TestCase("rock", "rock", 0)]
	[TestCase("paper", "paper", 0)]
	[TestCase("scissors", "scissors", 0)]
	[TestCase("rock", "paper", 2)]
	[TestCase("rock", "scissors", 1)]
	[TestCase("paper", "rock", 1)]
	[TestCase("paper", "scissors", 2)]
	[TestCase("scissors", "rock", 2)]
	[TestCase("scissors", "paper", 1)]
	public void CheckWinConditions(string playerOneGesture, string playerTwoGesture, int winner)
	{
		game.playerOne.throwGesture (playerOneGesture);
		game.playerTwo.throwGesture(playerTwoGesture);
		int result = game.getWinner();
		Assert.AreEqual (winner, result);
	}


}