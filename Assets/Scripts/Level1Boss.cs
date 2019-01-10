using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Boss : MonoBehaviour {
    public GameObject prefab;
    public Vector2 throwForce;
    public float fireRate = 0.5f;
    public bool enable;
    public Transform bulletStartPos;
    float moveDirect = 0f;
    Rigidbody2D rb;
    Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Invoke("Throw", 5f);    
    }
	
	// Update is called once per frame
	void FixedUpdate () {
    }

    void Throw()
    {
        GameObject obj = Instantiate(prefab, bulletStartPos.position, Quaternion.identity); // intsantiate membuat object baru ke dalam scene
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        anim.SetBool("Throw", true);
        rb.AddForce(throwForce);
        Invoke("Throw", 1.2f);
    }
}
