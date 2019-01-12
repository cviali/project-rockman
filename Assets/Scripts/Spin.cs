using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
    // Update is called once per frame
    public AudioClip spawn;

	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, 500) * Time.deltaTime);
    }

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

    void OnTriggerEnter2D()
    {

    }
}
