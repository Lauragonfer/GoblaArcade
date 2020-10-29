
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public Canvas logoCanvas, menuCanvas, helpCanvas;

    public float fallDelay = 3f;

    private void Start()
    {
        logoCanvas.enabled = true;
        menuCanvas.enabled = false;
        helpCanvas.enabled = false;
        Invoke("QuitLogo", fallDelay);
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("World_01_1");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        QuitLogo();
        SceneManager.LoadScene("Menu");
    }

    public void HelpGame()
    {
        logoCanvas.enabled = false;
        menuCanvas.enabled = false;
        helpCanvas.enabled = true;
    }

    public void QuitLogo()
    {
        logoCanvas.enabled = false;
        menuCanvas.enabled = true;
    }
}