using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    private bool isGameOn;
    private bool win;

    private Text info;
    private const string helpInfo = "W: Forward, S: Backward, A: Turn Left, D: Turn Right";

    [SerializeField]
    private float delayBeforeLoading = 1f;

    [SerializeField]
    private float delayBeforeInfoOff = 5f;

    private float timeElapsedSinceGameOver;

    private float timeElapsedSinceInfoOn;

    void Start()
    {
        //Initialisation
        isGameOn = true;
        win = false;
        info = GameObject.FindGameObjectWithTag("Info").GetComponent<Text>();
        info.text = "Get to the ambulance at entrance on level 1 to win the game\n"+helpInfo;
    }



    void Update()
    {
        // delay loading scene ref: https://www.youtube.com/watch?v=Oe9BZVnoedE

        //Wait for the time of delayBeforeLoading to end the game
        if (!isGameOn)
        {
            timeElapsedSinceGameOver += Time.deltaTime;
            if (timeElapsedSinceGameOver >= delayBeforeLoading)
            {
                if (win)
                    WinGame();
                else
                    LoseGame();
            }
        }

        //Automatically turn off the help text after the time of delayBeforeInfoOff
        if (info.gameObject.activeSelf)
        {
            timeElapsedSinceInfoOn += Time.deltaTime;
            if (timeElapsedSinceInfoOn >= delayBeforeInfoOff)
                HelpOff();
        }


        //Turn on/off the help text by pressing H key
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!info.gameObject.activeSelf)
                Help();
            else
                HelpOff();
        }
    }

    //Help text on
    public void Help(string infoText = helpInfo)
    {
        info.text = infoText;
        info.gameObject.SetActive(true);
        timeElapsedSinceInfoOn = 0;
    }

    //Help text off
    public void HelpOff()
    {
        info.gameObject.SetActive(false);
        timeElapsedSinceInfoOn = 0;
    }

    //Call the method to terminate the game
    public void GameOver(bool winGame)
    {
        if (isGameOn)
        {
            isGameOn = false;
            win = winGame;
        }
    }


    //Go to win screen
    private void WinGame()
    {
        SceneManager.LoadSceneAsync("win screen");
    }

    //Go to lose screen
    private void LoseGame()
    {
        SceneManager.LoadSceneAsync("lose screen");
    }

}
