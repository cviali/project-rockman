using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    AudioSource audioSource;
    bool isJumping;
    bool isDead;
    bool isShoot;
    public bool isClimbing;
    public int moveDirection;
    public int moveVertical;
    int life = 3;
    public float jumpForce = 200f;
    public float distance;
    public LayerMask ladder;
    public GameObject gameOverScreen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameOverScreen.SetActive(false);
    }

    private void Lari()
    {
        float maxSpeedX = 1f; // 3 meter/second
        moveDirection = (int)Input.GetAxisRaw("Horizontal");
        anim.SetInteger("MoveDirection", moveDirection);
        if (moveDirection == 0) return;

        // flip sprite facing x direction -1 or 1
        transform.localScale = new Vector2(moveDirection,
            transform.localScale.y);

        float currentVelocityX = rb.velocity.x;
        if (currentVelocityX < maxSpeedX &&
            currentVelocityX > -maxSpeedX)
        {
            rb.velocity = new Vector2(moveDirection, rb.velocity.y);
        }
    }


    

void FixedUpdate()
    {
        if (isDead)
        {
            gameOverScreen.SetActive(true);
        } 
        Lari();
        Lompat();
        Nembak();

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladder);

        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isClimbing = true;
                anim.SetBool("Climb", true);
            }
            else if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                isClimbing = false;
                anim.SetBool("Climb", false);
            }

            if (isClimbing == true)
            {
                moveVertical = (int)Input.GetAxisRaw("Vertical");
                rb.velocity = new Vector2(rb.velocity.x, moveVertical);
                rb.gravityScale = 0;
            }
            else
            {
                rb.gravityScale = 1;
            }
        }
    }

    void Lompat()
    {

        if (Input.GetKeyDown("space") && isJumping == false)
        {
            isJumping = true;
            anim.SetBool("IsJumping", isJumping);
            rb.AddForce(new Vector2(0, jumpForce));
        }

    }

    void Nembak()
    {
        if(Input.GetKey("e") )
        {
            isShoot = true;
            anim.SetBool("IsShoot", isShoot);
            GetComponent<ThrowObject>().enabled = true;
        }

        else
        {
            isShoot = false;
            anim.SetBool("IsShoot", isShoot);
            GetComponent<ThrowObject>().enabled = false;
        }


    }

    void LateUpdate()
    {
        if (isDead) return;
    }


    void OnTriggerStay2D(Collider2D col)
    {
        isJumping = false;
        anim.SetBool("IsJumping", isJumping);
    }

    void CekLanding()
    {
        isJumping = false;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        CekEnemy(col.gameObject);
    }

    void CekEnemy(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            isDead = true;
        }
    }
}
