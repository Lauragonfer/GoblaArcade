using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private const int Level01 = 4;
    private const int Menu = 0;

    public void PlayGame()
    {
        SceneManager.LoadScene(Level01);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(Menu);
    }
    
}
