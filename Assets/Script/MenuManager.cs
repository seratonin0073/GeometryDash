using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static int currentLevel = 1;//поточний відкритий рівень
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChooseLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void Settings()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }

    public void NextLevel()
    {
        int currentScene = SceneManager.sceneCount;
        int maxScene = SceneManager.sceneCountInBuildSettings;
        if(currentLevel + 1 >= maxScene)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentScene + 1);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
