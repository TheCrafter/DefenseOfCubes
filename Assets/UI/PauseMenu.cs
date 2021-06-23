using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        ui.SetActive(!ui.activeSelf);
        Time.timeScale = ui.activeSelf ? 0f : 1f;
    }

    public void Continue()
    {
        TogglePause();
    }

    public void Retry()
    {
        TogglePause();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        TogglePause();
        sceneFader.FadeTo(menuSceneName);
    }
}
