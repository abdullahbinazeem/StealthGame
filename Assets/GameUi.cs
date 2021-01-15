﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public GameObject gameLoseUI;
    public GameObject gameWinUI;
    bool gameIsOver;

	void Start()
	{
        Guard.OnGuardHasSpottedPlayer += ShowGameLoseUI;
        FindObjectOfType<Player>().OnReachEndOfLevel += ShowGameWinUI;
	}

	void Update()
    {
		if (gameIsOver)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
                SceneManager.LoadScene(0);
            }
		}  
    }

    void ShowGameWinUI ()
	{
        OnGameOver(gameWinUI);
	}

    void ShowGameLoseUI ()
	{
        OnGameOver(gameLoseUI);
    }

    void OnGameOver (GameObject gameOverUI)
	{
        gameOverUI.SetActive(true);
        gameIsOver = true;
        Guard.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
        FindObjectOfType<Player>().OnReachEndOfLevel -= ShowGameWinUI;

    }
}
