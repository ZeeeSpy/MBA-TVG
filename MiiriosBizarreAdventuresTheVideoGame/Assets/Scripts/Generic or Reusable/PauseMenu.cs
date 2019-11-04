/*
 * Script that handles the pause menu in all scenes. 
 * Pause is done by setting time scale to 0 and unlocking cursor.
 * nothing fancy.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;
    public GameObject pausemenu;

    void Update()
    {
      if (Input.GetButtonDown("Cancel"))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
            } else
            {
                Time.timeScale = 1;
                paused = false;
            }
        }

      if (paused)
        {
            pausemenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            pausemenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
