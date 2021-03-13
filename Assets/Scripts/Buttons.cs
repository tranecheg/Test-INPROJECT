using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }
    public void GameSettings()
    {
        SceneManager.LoadScene("GameSettings");
    }
}
