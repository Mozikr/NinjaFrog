using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _explosionParticlePrefab;

    public int health;
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;
    public AudioSource DeadSound;
    public float time;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        DeadSound = GetComponent<AudioSource>();
    }

    public void TakeDamage (int damage)
    {
        sr.material = matWhite;
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            Invoke("ResetMaterial", 0.1f);
        }
    }
    void ResetMaterial()
    {
        sr.material = matDefault;
    }
    void Die()
    {
        DeadSound.Play();
        Instantiate(_explosionParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, time);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ReloadScene"))
        {
            Die();
        }
    }

}
