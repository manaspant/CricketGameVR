using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Job of this script is to initialize the game to a sensible starting state, control game flow and timing, and handle gameover plus game timing

	public proceduralManager bowler; 			// procedural Manager is a bad name for this script, but on a schedule as tight as ours, I am NOT going to go through and refactor stuff if it runs fine.
										// so when you're reading this code, if you see procedural manager, think "bowler"



	public float bowlingDelayTime;		// How long after the readyForBall state is entered the bowler should release a ball


	public enum GameState {
		preGame,			// This would be for setup etc
		waitForUserReady,	// Once everything is set up for the player to face a delivery, but they haven't indicated that they're ready for a ball yet
		readyForBall,		// When the player is ready to face a delivery, and it will be released after a predetermined amount of time
		ballReleased,		// When the ball is bowled but before the player hits the ball
		ballBatted,			// Once the ball has been batted, and before it has either hit a board or come to a complete stop
		gameOver			// After a game has been played and we are ready to go into preGame once again
							// The reason preGame and gameOver are different is that in preGame we cannot be sure if there exists a high score yet or not.
							// A gameOver indicates that at least one full game was succesfully played.
	}

	GameState gameState;

	void Start () {

	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			bowler.throwBall ();
		}
		if (Input.GetMouseButtonDown (1)) {
			bowler.destroyBalls ();
		}
//		Debug.Log ("Game State is " + gameState);
//
//		switch (gameState) {
//		case GameState.preGame:
//			Debug.Log ("Pre game stuff");
//			break;
//		case GameState.waitForUserReady:
//			Debug.Log ("Ready to roll when you are, user");
//			break;
//		case GameState.readyForBall:
//			Debug.Log ("Okay let's wind up and bowl!");
//			break;
//		case GameState.ballReleased:
//			Debug.Log ("released!");
//			break;
//		case GameState.ballBatted:
//			Debug.Log ("Ball has been hit, let's see what to do now");
//			break;
//		case GameState.gameOver:
//			Debug.Log ("Game over!");
//			break;
//		}

	}




	public void setGameState(GameState newState){
		gameState = newState;
	}

//	public void bowlAfterDelay(float delayTime){
//		bowler.throwBall ();
//	}




	// check if the scene has a dead ball
	// by "dead ball" we mean a ball that has come to a halt before it hit anything. If a ball is dead, destroy its GameObject and set gamestate back to ReadyForBall.
	// returns -1 if called while there is no batted ball, 0 if the batted ball is not dead, 1 if it succesfully kills a dead ball, and 192 on error
	// This is wonky behaviour, yes, but imma let myself get away with this becuase it's a reference to the glorious idiocy that is the behaviour of PHP's sleep() function when run on Windows.
	public int handleDeadBall(){
		if (gameState != GameState.ballBatted) {
			Debug.Log ("The ball hasn't been played yet so there's no dead ball to check for");
			return -1;
		} 
		else if (gameState == GameState.ballBatted) {
			// check if there is a ball in play. There absolutely should be. If there isn't, error.
			GameObject ball = GameObject.FindGameObjectWithTag("ball");
			if (!ball) {
				Debug.Log ("How the hell are we in ballBatted state if there's no ball? Something has gone terribly wrong.");
				return 192;
			} 
			else {
				// once we are assured there is a ball in play, check its velocity. If it is zero, it is dead. If not zero, then the ball is not dead
				Vector3 ballVelocity = ball.GetComponent<Rigidbody>().velocity;
				if (ballVelocity == Vector3.zero) {
					Debug.Log ("Ball is dead!");
					Destroy(ball);
					return 1;
				} 
				else {
					Debug.Log ("Ball is not yet dead (it can dance and it can sing)");
					return 0;
				}
			}

		}
		else{
			Debug.Log ("How the hell did control flow ever get here? Something has gone terribly wrong.");
			return 192;
		}
	}
	/* End of handleDeadBall declaration */



}
