using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu.");
    }
}
