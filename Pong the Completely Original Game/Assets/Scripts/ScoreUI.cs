using UnityEngine;
using System.Collections;

public class ScoreUI : MonoBehaviour {

    public int scorePlayer;
    public int scorePlayerAI;
    public GUIStyle style;
    public GameObject Puck;


    public int winningScore = 5;


    


    void OnGUI()
    {
        // calculate the top screen center of the screen
        float x = Screen.width / 2f;
        float y = 30f;
        float width = 300f;
        float height = 20f;
        string text = scorePlayerAI + " : " + scorePlayer;

        // draw the label at the top center of the screen
        GUI.Label(new Rect(x - (width / 2f), y, width, height), text, style);

        if (scorePlayer >= winningScore || scorePlayerAI >= winningScore) //someone wins 
        {
            // disable ball
            GameObject ball = GameObject.Find("Ball");
            if (ball != null)
            {
                ball.SetActive(false);
            }

            // create winning message
            string winMessage = "The AI won";
            if (scorePlayerAI >= winningScore)
            {
                winMessage = "You won";
            }

            // show winning message at the center of the screen
            y = Screen.height / 2f;
            GUI.Label(new Rect(x - (width / 2f), y + (height / 2f), width, height), winMessage, style);
            Application.Quit();

        }
    }


  

   
}

