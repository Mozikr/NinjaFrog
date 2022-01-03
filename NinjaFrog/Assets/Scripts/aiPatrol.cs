using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiPatrol : MonoBehaviour
{
    public int speed;
    Rigidbody2D rb;
    public GameObject LeftCollider;
    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.Translate(-Vector2.right *speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collisionForEnemy"))
        {
            transform.Rotate(0.0f, -180f, 0.0f);
        }else if (other.gameObject.CompareTag("collisionForEnemy2"))
        {
            transform.Rotate(0.0f, 180f, 0.0f);
        }
    }
    

}