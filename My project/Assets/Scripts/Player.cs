using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 11f;

    private float movementX;

    public GamePlayUI Gamecontroller;

    private Rigidbody2D myBody;


    private Animator anim;

    private string WALK_ANIMATION = "isRun";
    private string JUMP_ANIMATION = "isJump";


    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";
    // Start is called before the first frame update

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if(movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            transform.localScale = new Vector3(0.6f, 0.6f, 0);
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            transform.localScale = new Vector3(-0.6f,0.6f,0);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool(WALK_ANIMATION, false);
            anim.SetBool(JUMP_ANIMATION, true);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG) || collision.gameObject.CompareTag("Ghost"))
        {
            anim.SetTrigger("die");
            Gamecontroller.GameOver();
            Destroy(gameObject,0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ghost"))
        {
            anim.SetTrigger("die");
            Gamecontroller.GameOver();
      
           Destroy(gameObject,0.5f);
           

        }
    }
}
























