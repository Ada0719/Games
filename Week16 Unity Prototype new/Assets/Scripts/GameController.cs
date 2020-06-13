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
        isGameOn = true;
        win = false;
        info = GameObject.FindGameObjectWithTag("Info").GetComponent<Text>();
        info.text = "Get to the ambulance at entrance on level 1 to win the game\n"+helpInfo;
    }



    void Update()
    {
        // delay loading scene ref: https://www.youtube.com/watch?v=Oe9BZVnoedE
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

        if (info.gameObject.activeSelf)
        {
            timeElapsedSinceInfoOn += Time.deltaTime;
            if (timeElapsedSinceInfoOn >= delayBeforeInfoOff)
                HelpOff();
        }



        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!info.gameObject.activeSelf)
                Help();
            else
                HelpOff();
        }
    }

    public void Help(string infoText = helpInfo)
    {
        info.text = infoText;
        info.gameObject.SetActive(true);
        timeElapsedSinceInfoOn = 0;
    }

    public void HelpOff()
    {
        info.gameObject.SetActive(false);
        timeElapsedSinceInfoOn = 0;
    }

    public void GameOver(bool winGame)
    {
        if (isGameOn)
        {
            isGameOn = false;
            win = winGame;
        }
    }



    private void WinGame()
    {
        SceneManager.LoadSceneAsync("win screen");
    }

    private void LoseGame()
    {
        SceneManager.LoadSceneAsync("lose screen");
    }

}
