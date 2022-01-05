using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetHit : MonoBehaviour
{
    public int health = 20;
    [SerializeField] private GameObject _explosionParticlePrefab;
    [SerializeField] private GameObject _diedexposion;
    public int indexToReload;
  //  public AudioSource DEEADSOUND;
    public float timetoDead;
    private HearManager hearts;

    private void Start()
    {
        hearts = FindObjectOfType<HearManager>();
     //   DEEADSOUND = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            hearts.MinusHearts(1);
            Debug.Log("Dostalem w łeb");
            health --;
           // Instantiate(_explosionParticlePrefab, transform.position, Quaternion.identity);
        }
        else if (health <= 0)
        {
            //  Instantiate(_diedexposion, transform.position, Quaternion.identity);
            //DEEADSOUND.Play();
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Destroy(gameObject, timetoDead);
            SceneManager.LoadScene(indexToReload);
        }

        if (other.gameObject.CompareTag("ReloadScene"))
        {
            // DEEADSOUND.Play();
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Instantiate(_explosionParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject, timetoDead);
        }

    }
}
   
