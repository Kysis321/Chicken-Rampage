using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winCond : MonoBehaviour
{

    public int chick;
    public float gameEnd = 5;
    public bool chickCap;
    public bool timerStart;
    public Text winText;
    public Text gameEndText;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (chick == 2)
        {
            chickCap = true;
        }

        if (chickCap)
        {
            winText.text = "You WIN!";

            timerStart = true;

        }
        if(timerStart)
        {
            if (gameEnd > 0)
            {
                gameEnd -= Time.deltaTime;
                DisplayTime(gameEnd);
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

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        gameEndText.text = "Returning to Menu : " + string.Format("{00}", seconds);
    }
}
