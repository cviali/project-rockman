using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    public GameObject explosion;

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            explosion = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
