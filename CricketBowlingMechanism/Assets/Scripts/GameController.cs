using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// This is the script that keeps track of the game state
	// Job of this script is to initialize the game to a sensible starting state, control timing, and tell the game when its over

	
	public enum gameState {
		preGame,		// This would be for setup etc
		readyForBall,	// When the player is ready to face a delivery, release it after some predefined amount of time
		ballReleased,	// When the ball is bowled but before the player hits the ball
		ballBatted,		// Once the ball has been batted, and before it has either hit a board or come to a complete stop
		gameOver
	}


	void Start () {
		
	}

	void Update () {
		
	}
}
