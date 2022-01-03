using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int levelToUnlock;
    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
