
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapManager : MonoBehaviour
{
    public float fallDelay = 2f;
    
    private const int Level01 = 4;

    private void Start()
    {
        Invoke("QuitMap", fallDelay);
    }

    public void QuitMap()
    {
        SceneManager.LoadScene(Level01);
    }
}