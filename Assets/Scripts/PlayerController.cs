using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    public AudioClip getCoin, getHit, getHP, defeated;
    bool isJumping;
    bool isDead;
    bool isShoot;
    public bool isInvincible;
    public bool isClimbing;
    public int moveDirection;
    public int moveVertical;
    public int life = 1;
    int score = 0;
    public float jumpForce = 200f;

    public float distance;
    public LayerMask ladder;

    public Text lifeText, scoreText, gameOverText, finalScoreText;
    public GameObject gameOverScreen;

    public float limit = 1f;
    float deltaTime = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameOverScreen.SetActive(false);
    }


    private AudioSource[] allAudioSources;
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    void FixedUpdate(){
        if (isDead)
        {
            StopAllAudio();
            //PlaySound(defeated);
            gameOverScreen.SetActive(true);
        }

        if (isInvincible)
        {
            isInvincible = false;
        }

        Lari();
        Lompat();
        Nembak();

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladder);

        if (hitInfo.collider != null) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                isClimbing = true;
                anim.SetBool("Climb", true);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
            }
        } else {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                isClimbing = false;
            }
        }

        if (isClimbing == true && hitInfo.collider != null){
            moveVertical = (int)Input.GetAxisRaw("Vertical");
            anim.SetInteger("MoveVertical", moveVertical);
            rb.velocity = new Vector2(rb.velocity.x, moveVertical);
            rb.gravityScale = 0;
        } else {
            anim.SetBool("Climb", false);
            rb.gravityScale = 1;
        }

        scoreText.text = "Score: " + score;
        lifeText.text = "Life: " + life;
    }

    void PlaySound(AudioClip sound)
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
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

    void Lompat()
    {

        if (Input.GetKeyDown("space") && isJumping == false)
        {
            isJumping = true;
            anim.SetBool("IsJumping", isJumping);
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    void CekLanding()
    {
        isJumping = false;
    }

    void CekEnemy(GameObject obj)
    {
        if (obj.CompareTag("CompleteMark2"))
        {
            gameOverText.text = "Level 2 Complete!";
            score = score + 1000;
            finalScoreText.text = "Total Score: " + score;
            gameOverScreen.SetActive(true);
        }

        if (obj.CompareTag("CompleteMark"))
        {
            gameOverText.text = "Level 1 Complete!";
            finalScoreText.text = "Total Score: " + score;
            gameOverScreen.SetActive(true);
        }

        if (obj.CompareTag("Coin"))
        {
            PlaySound(getCoin);
            Destroy(obj.gameObject);
            score = score + 10;
        }

        if (obj.CompareTag("CoinHP"))
        {
            PlaySound(getHP);
            Destroy(obj.gameObject);
            life = life + 1;
        }

        if (obj.CompareTag("Hazard"))
        {
            isDead = true;
        }

        if (obj.CompareTag("Enemy") && life != 1)
        {
            if (isInvincible)
            {
                return;
            }
            PlaySound(getHit);
            anim.SetTrigger("Hit");
            rb.AddForce(new Vector2(-60f * transform.localScale.x, 50f));
            life--;
            isInvincible = true;
        }
        else if(obj.CompareTag("EnemyBullet") && life != 1)
        {
            if (isInvincible)
            {
                return;
            }
            PlaySound(getHit);
            anim.SetTrigger("Hit");
            rb.AddForce(new Vector2(-60f * transform.localScale.x, 50f));
            life--;
            Destroy(obj.gameObject);
            isInvincible = true;
        }
        else if (obj.CompareTag("Enemy") || obj.CompareTag("EnemyBullet") && life == 1)
        {
            isDead = true;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        isJumping = false;
        anim.SetBool("IsJumping", isJumping);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (isInvincible)
        {
            return;
        }
        else
        {
            CekEnemy(col.gameObject);
        }
    }
}
