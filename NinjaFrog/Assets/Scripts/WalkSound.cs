using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WalkSound : MonoBehaviour
{
    public AudioSource walk;
   
    void Start()
    {
        walk = GetComponent<AudioSource>();
    }
    private void footStep()
    {
        walk.Play();
    }
}
