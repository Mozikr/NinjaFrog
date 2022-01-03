using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int _LevelIndexToLoad;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_LevelIndexToLoad);
            gameManager.WinLevel();
        }
    }
}
