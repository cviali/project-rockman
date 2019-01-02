using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    AudioSource audioSource;
    bool isJumping;
    bool isDead;
    bool isShoot;
    public int moveDirection;
    public float jumpForce = 200f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
            rb.AddForce(new Vector2(10f * moveDirection, 0f));
        }
    }
    void FixedUpdate()
    {
        if (isDead) return;
        Lari();
        Lompat();
        Nembak();
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

        Camera cam = Camera.main;

        Vector3 camPosition = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);

        if (camPosition.x >= 13.6f || camPosition.y >= -0.75f)
        {
            camPosition = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
            cam.transform.position = camPosition;
        } else
        {
            camPosition = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);
            camPosition.y = -1.511f;
            cam.transform.position = camPosition;
        }
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
            anim.SetTrigger("IsHitted");
        }
    }
}
