using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public int indexToReload;
    private float timeElapsed;
    bool startTimer = false;
    public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                startTimer = true;
            }
        }
   

    //NOW, YOU CAN USE THIS BOOL STATE(TRUE/FALSE) IN UPDATE FUNCTION
    void Update()
    {
       
        if (startTimer == true)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 2f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}

