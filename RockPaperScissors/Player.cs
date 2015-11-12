using System;

public class Player
{
	public string name;
	public string gesture;
	static Random random = new Random();
	string[] gestureOptions = { "rock", "paper", "scissors" };

	public Player (string playerName)
	{
		name = playerName;
	}

	public Player ()
	{
		name = "COMPUTER";
	}

	public virtual void throwGesture(string playerGesture)
	{
		gesture = playerGesture;
	}

	public virtual void throwGesture()
	{
		var selection = random.Next (0, 3);
		gesture = gestureOptions [selection];

	}
}

