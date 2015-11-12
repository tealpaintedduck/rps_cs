using NUnit.Framework;
using System;

[TestFixture]
public class PlayerTests

{
	Player player;
	Player computerPlayer;
	[SetUp]
	public void GetReady()
	{
		player = new Player("Roland");
		computerPlayer = new Player ();
	}



	[TearDown]
	public void Clean() {}


	[Test]
	public void PlayerHasName()
	{
		string result = player.name;
		Assert.AreEqual ("Roland", result);
	}

	[Test]
	public void ComputerPlayerHasName()
	{
		string result = computerPlayer.name;
		Assert.AreEqual ("COMPUTER", result);
	}

	[Test]
	public void PlayerThrowsGesture()
	{
		player.throwGesture("rock");
		string result = player.gesture;
		Assert.AreEqual("rock", result);
	}

	[Test]
	public void ComputerPlayerThrowsGesture()
	{
		computerPlayer.throwGesture ();
		string result = computerPlayer.gesture;
		string[] gesturesArray = { "rock", "paper", "scissors" };
		int included = Array.IndexOf (gesturesArray, result);
		Assert.AreNotEqual (-1, included);
	}

}

