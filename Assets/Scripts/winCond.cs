using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winCond : MonoBehaviour
{

    public int chick;
    public float timerText = 10;
    public float gameEnd = 5;
    public bool chickCap;
    public bool endStart;
    public bool roundStart;
    public Text winText;
    public Text gameEndText;
    public Text endText;
    

    // Start is called before the first frame update
    void Start()
    {
        roundStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (roundStart)
        {
            if (timerText > 0)
            {
                timerText -= Time.deltaTime;
                DisplayTimeRound(timerText);
            }
            else
            {
                timerText = 0;
                winText.text = "You Lose!";
                endStart = true;
            }
        }

        if (chick == 2)
        {
            chickCap = true;
        }

        if (chickCap)
        {
            winText.text = "You WIN!";

            endStart = true;

        }
        if(endStart)
        {
            if (gameEnd > 0)
            {
                gameEnd -= Time.deltaTime;
                DisplayTimeEnd(gameEnd);
                roundStart = false;
            }
            else
            {
                Application.LoadLevel("MenuScene");
            }
        }
    }
  
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Chicken"))
        {
            chick++;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            chick--;
        }
    }

    void DisplayTimeRound(float timeToDisplay)
    {
        timeToDisplay += 1;

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        endText.text = "Time Remaining : " + string.Format("{00}", seconds);
    }

    void DisplayTimeEnd(float timeToDisplay)
    {
        timeToDisplay += 1;

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        gameEndText.text = "Returning to Menu : " + string.Format("{00}", seconds);
    }
}
