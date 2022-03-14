using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;
    private void Awake()
    {
        isPaused = false;
    }
    public void Pause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }
    private void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        print(name + ": Resume");
    }
    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        print(name + ": Pause");
    }
    public void QuitGame()
    {
        ResumeGame();
        //SceneManager.LoadScene(sceneName: "LevelSelection");
    }
}
