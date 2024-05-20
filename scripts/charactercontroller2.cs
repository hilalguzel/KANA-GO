using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class charactercontroller2 : MonoBehaviour
{
    public float jumpForce = 20.0f;
    public float speed = 1.0f;
    private float moveDirection;
    private Vector3 charPos;
    public static float timer =0.0f;
    public static int timer_board=0;

    private bool jump;
    private bool grounded;
    private bool moving;
    private Rigidbody2D _rigidbody2D;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    private int ground_controller=0;
    [SerializeField] private TextMeshProUGUI _text;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _text.text = totalscore.total_timer.ToString();
        timer++;
        if ((timer/50)==1) 
        {
            timer = 0;
            totalscore.total_timer--;

            if (totalscore.total_timer == 0) 
            {
                totalscore.total_timer = 20;
                SceneManager.LoadScene(1);
            }
        }
        _rigidbody2D.velocity = new Vector2(x: moveDirection * speed, y: _rigidbody2D.velocity.y);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (grounded == true && (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D))))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                _anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                _anim.SetFloat("speed", speed);
            }
        }

        else if (grounded == true)
        {
            moveDirection = 0.0f;
            _anim.SetFloat("speed", 0.0f);
        }
        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            grounded = false;
            _anim.SetBool("grounded", false);
        }
        ground_controller++;
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            _anim.SetBool("grounded", true);
        }
        else 
        {
            grounded = false;
            _anim.SetBool("grounded", false);
        }
    }
}
