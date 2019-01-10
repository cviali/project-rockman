using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowObject : MonoBehaviour {
    public GameObject prefab;
    public Vector2 throwForce;
    public float fireRate = 0.5f;
    public bool enable;
    public Transform bulletStartPos;
    float moveDirect = 0f;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void OnEnable()
    {
        enable = true;
        Throw();
    }

    void Throw()
    {
        if (!enable)
        {
            return;
        }
        GameObject obj = Instantiate(prefab, bulletStartPos.position, Quaternion.identity); // intsantiate membuat object baru ke dalam scene
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(throwForce);
        Invoke("Throw", fireRate);
    }
}

