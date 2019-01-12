using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour {
    public int bulletCount;
    public GameObject prefab;
    public Vector2 throwForce;
    public float fireRate = 0.5f;
    public bool enable;
    public Transform bulletStartPos;
    public PlayerController pc;
    float moveDirect = 0f;

    void Start()
    {
        pc = GetComponent<PlayerController>();
        moveDirect = pc.transform.localScale.x;
        Throw();
    }

	// Use this for initialization
	void OnEnable () {
        enable = true;
        Throw();
	}
    void OnDisable()
    {
        // set var buat stop
        enable = false;
    }
    
    void Throw() {
        if (!enable)
        {
            return;
        }
        moveDirect = pc.transform.localScale.x;
        throwForce = new Vector2(moveDirect * 150f, 0f);
        GameObject obj = Instantiate(prefab, bulletStartPos.position, Quaternion.identity); // intsantiate membuat object baru ke dalam scene
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(throwForce);
        bulletCount++;
        Invoke("Throw", fireRate);
	}
}
