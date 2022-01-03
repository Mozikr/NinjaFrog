using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Frog : MonoBehaviour
{
    [SerializeField] int _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] private GameObject _collectedObjectApple;
    [SerializeField] private GameObject _collectedObjectKiwi;
    [SerializeField] private GameObject _collectedObjectMelon;
    [SerializeField] private GameObject _collectedObjectAnanas;
    Rigidbody2D _rb2d;
    public Transform _groundCheckPoint;
    public float _groundCheckRadius;
    public LayerMask _groundLayer;
    private bool _isTouchingGround;
    private float _horizontalMove;
    public Animator animator;
    private bool _isFacingRight = true;
    public int health = 10;
    private PointManager pointsManager;
    //public AudioSource Pick;
    public ParticleSystem dust;
    //private PickFruitSound PickSound;


    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        pointsManager = FindObjectOfType<PointManager>();
        //PickSound = FindObjectOfType<PickFruitSound>();
     //   Pick = GetComponent<AudioSource>();
    }
    private void Update()
    {

        _horizontalMove = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));

        if (!_isTouchingGround)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
     
       if(_isFacingRight && _horizontalMove < 0)
        {
            Flip();
        }else if(!_isFacingRight && _horizontalMove > 0)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.W) && _isTouchingGround)
        {
            CreateDust();
            FindObjectOfType<AudioManager>().Play("Jump");
            //_rb2d.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, _jumpForce);
        }

        _isTouchingGround = Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _groundLayer);

    }
    private void FixedUpdate()
    {

        if (Input.GetKey("d"))
        {
            _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            _rb2d.velocity = new Vector2(-_speed, _rb2d.velocity.y);
        }
        else
        {
            _rb2d.velocity = new Vector2(0, _rb2d.velocity.y);
        }
    }
    void Flip()
    {
        CreateDust();
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0.0f, -180f, 0.0f);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            FindObjectOfType<AudioManager>().Play("PickingUpFruit");
            Debug.Log("jabko zebrane");
            Instantiate(_collectedObjectApple, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointsManager.AddPoints(1);

        }
        else if (collision.gameObject.CompareTag("Pineapple"))
        {
            FindObjectOfType<AudioManager>().Play("PickingUpFruit");
            Debug.Log("ananas zebrany");
            Instantiate(_collectedObjectAnanas, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointsManager.AddPoints(2);
        }
        else if (collision.gameObject.CompareTag("Melon"))
        {
            FindObjectOfType<AudioManager>().Play("PickingUpFruit");
            Debug.Log("melon zebrany");
            Instantiate(_collectedObjectMelon, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointsManager.AddPoints(5);
        }
        else if (collision.gameObject.CompareTag("Kiwi"))
        {
            FindObjectOfType<AudioManager>().Play("PickingUpFruit");
            Debug.Log("kiwi zebrany");
            Instantiate(_collectedObjectKiwi, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointsManager.AddPoints(3);
        }

    }
    void CreateDust()
    {
        dust.Play();
    }


}


/* if (Input.GetKey(KeyCode.D))
         {
             transform.Translate(Vector2.right * (Time.deltaTime * _speed));
               if (mySpriteRenderer != null)
               {
                mySpriteRenderer.flipX = false;
               }
         } else if (Input.GetKey(KeyCode.A))
             {
             transform.Translate(Vector2.left * (Time.deltaTime * _speed));

             /* if (mySpriteRenderer != null)
              {
              mySpriteRenderer.flipX = true;
              }
         }
         if (Input.GetKey(KeyCode.W) && _isTouchingGround && _rb2d.velocity.y ==0)
         {
             //_rb2d.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
             _rb2d.velocity = new Vector2(_rb2d.velocity.x, _jumpForce);
         }*/
