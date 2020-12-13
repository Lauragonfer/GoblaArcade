
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public Canvas logoCanvas, menuCanvas, helpCanvas;

    public float fallDelay = 2f;

    private const int Menu = 0;
    private const int Level01 = 4;

    private void Start()
    {
        logoCanvas.enabled = true;
        menuCanvas.enabled = false;
        helpCanvas.enabled = false;
        Invoke("QuitLogo", fallDelay);
    }


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

    public void BackMenuInHelpMenu()
    {
        logoCanvas.enabled = false;
        menuCanvas.enabled = true;
        helpCanvas.enabled = false;
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