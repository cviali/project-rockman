using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public AudioClip spawn;

    void PlaySound(AudioClip sound)
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
    }

    void OnBecameVisible()
    {
        PlaySound(spawn);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
