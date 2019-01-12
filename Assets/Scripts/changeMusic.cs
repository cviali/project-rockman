using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour {
    public AudioClip music;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlaySound(music);
        }
    }

    void PlaySound(AudioClip sound)
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
    }
}
