using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PickFruitSound : MonoBehaviour
{
    public AudioSource pick;
    private PointManager pointsManager;
    [SerializeField] private GameObject _collectedObjectPrefab;
    void Start()
    {
        pick = GetComponent<AudioSource>();
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("Player"))
         {
             pick.Play();
         }
     }*/

    public void Picking()
    {
        pick.Play();
    }
}
