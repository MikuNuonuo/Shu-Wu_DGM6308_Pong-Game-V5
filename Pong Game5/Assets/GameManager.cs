using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
	
	public static int PlayerScore1 = 3;
	public static int CoinScore = 0;
	
	public GUISkin layout;
	
	GameObject theBall;
	
    // Start is called before the first frame update
    void Start(){
		theBall = GameObject.FindGameObjectWithTag("Ball");
        
    }
	
	public static void Score(string BottomWall) {
			PlayerScore1--;
		
	}


  	void OnGUI () {
		GUI.skin = layout;
		GUI.Label(new Rect (Screen.width / 2 - 250 - 12, 20, 100, 100), "HP: " + PlayerScore1);
		GUI.Label(new Rect(Screen.width / 2 +100, 20, 160, 100), "Score: " + CoinScore);

		if (GUI.Button (new Rect (Screen.width / 2 - 60, 35, 120, 53), "RESTART")) {
			PlayerScore1 = 3;
			CoinScore = 0;
			theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
			PlayAgain();
		}

		if (PlayerScore1 == 0) {
			GUI.Label(new Rect (Screen.width / 2 - 100, 200, 2000, 1000), "YOU LOSE!");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		}else if(CoinScore == 5){			
			GUI.Label(new Rect (Screen.width / 2 - 80, 200, 2000, 1000), "YOU WIN!");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		}
	}	

    public void IncrementScore()
    {
        CoinScore++;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main5");
    }

}