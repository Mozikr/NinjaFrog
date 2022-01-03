using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
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
