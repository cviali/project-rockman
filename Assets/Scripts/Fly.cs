using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {

    Rigidbody2D rb;
    public float speed = 0.05f;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = new Vector2(transform.localScale.x * speed, 0);
	}
}
