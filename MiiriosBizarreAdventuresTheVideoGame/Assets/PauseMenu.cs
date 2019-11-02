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
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
