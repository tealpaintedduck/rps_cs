
using System;
using System.Collections.Generic;

public class Game 
{
	public Player playerOne;
	public Player playerTwo;
	public Player winningPlayer;
	Dictionary<string, int> winConditions = new Dictionary<string, int> ();


	public Game (Player firstPlayer, Player secondPlayer)
	{
		playerOne = firstPlayer;
		playerTwo = secondPlayer;
		winConditions.Add(("rock, paper"), 2);
		winConditions.Add(("rock, scissors"), 1);
		winConditions.Add(("paper, scissors"), 2);
		winConditions.Add(("paper, rock"), 1);
		winConditions.Add(("scissors, paper"), 1);
		winConditions.Add(("scissors, rock"), 2);
	}

	public bool hasWinner()
	{
		return !(playerOne.gesture == playerTwo.gesture || playerOne.gesture == null || playerTwo.gesture == null);
	}

	public int getWinner()
	{
		if(hasWinner() == true)
			return winConditions[playerOne.gesture + ", " + playerTwo.gesture];
		else
			return 0;
	}
}
