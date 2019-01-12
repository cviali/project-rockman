using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Boss : MonoBehaviour {
    public GameObject prefab;
    public Transform bulletStartPos;
    public AudioClip jump, throwBullet, damaged, bomExploded;
    Rigidbody2D rb;
    Animator anim;

    public int life = 20;
    bool isReady = true;
    int readyMeter = 3;
    bool play;

    public float limit = 2f;
    float deltaTime = 0;

    public GameObject bossLayout, explosion, completeMark;
    public Slider healthBar;

    private AudioSource[] allAudioSources;
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameObject.SetActive(true);
    }

    void Update()
    {
        healthBar.value = life;
    }

    void PlaySound(AudioClip sound)
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!play)
        {
            return;
        }

        if (life == 0)
        {
            StopAllAudio();
            explosion = Instantiate(explosion, transform.position, transform.rotation);
            completeMark = Instantiate(completeMark, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        deltaTime += Time.deltaTime;

        int action = Random.Range(0, 2);

        if (deltaTime >= limit)
        {
            switch (action)
            {
                case 0:
                    Jump();
                    break;
                case 1:
                    Ready();
                    break;
            }
            deltaTime = 0;
        }
        healthBar.value = life;
    }

    void OnBecameVisible()
    {
        play = true;
        bossLayout.SetActive(true);
    }

    void OnBecameInvisible()
    {
        play = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        CekObject(col.gameObject);
    }

    void CekObject(GameObject obj)
    {
        if (obj.CompareTag("Bullet"))
        {
            PlaySound(damaged);
            Destroy(obj.gameObject);
            life = life - 1;
            readyMeter = readyMeter - 1;
        }

        if(readyMeter == 0)
        {
            isReady = false;
            anim.SetBool("Ready", isReady);
            readyMeter = 3;
        }
    }

    void Ready()
    {
        isReady = true;
        anim.SetBool("Ready", isReady);
        if (isReady)
        {
            anim.SetTrigger("Throw");
        }
        else
        {
            PlaySound(bomExploded);
        }
    }

    void Jump()
    {
        PlaySound(jump);
        rb.AddForce(new Vector2(25f * transform.localScale.x, 200f));
    }

    void Throw()
    {
        PlaySound(throwBullet);
        GameObject obj = Instantiate(prefab, bulletStartPos.position, Quaternion.identity); // intsantiate membuat object baru ke dalam scene
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(100f * transform.localScale.x, 100f));
        
        isReady = false;
        anim.SetBool("Ready", isReady);
    }
}
