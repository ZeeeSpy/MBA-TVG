/*
 * Script that handles button presses in the main menu.
 * 
 * fairly generic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private const string GAME_BEATEN = "gamebeatenplayerprof";
    public GameObject MainMenu;
    public GameObject LevelSelect;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
       SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
       Application.Quit();
    }

    public void LevelSwitch(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public void LevelSelectButton()
    {
        if (PlayerPrefs.HasKey(GAME_BEATEN))
        {
            Debug.Log("Game Not Beaten");
            MainMenu.SetActive(false);
            LevelSelect.SetActive(true);
        }
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        LevelSelect.SetActive(false);
    }

    public void CheekyFinishTheGame()
    {
        PlayerPrefs.SetInt(GAME_BEATEN, 1);
    }

    public void DeleteEverything()
    {
        PlayerPrefs.DeleteAll();
    }
}
