using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelToUnlockAtTheEnd : MonoBehaviour
{
    public int levelToUnlock2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock2);
        }
    }
}