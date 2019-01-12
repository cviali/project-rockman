using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    public AudioSource audioSource;
    public GameObject explosion, coin;

    void OnBecameVisible()
    {
        audioSource.Play();
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        CekObject(col.gameObject);
    }

    void CekObject(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            explosion = Instantiate(explosion, obj.transform.position, obj.transform.rotation);
            coin = Instantiate(coin, obj.transform.position, obj.transform.rotation);
            Destroy(gameObject);
            Destroy(obj.gameObject);
        }
    }
}
