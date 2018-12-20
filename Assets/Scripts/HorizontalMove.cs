using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{

    Rigidbody2D rb; // reference to rigidbody2d of the attached gameobject
    public float movementSpeed = 0.5f;
    //public Transform frontbottom = null;
    private float localScaleX = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //RaycastHit2D hit = Physics2D.Raycast(frontbottom.position, frontbottom.position);

        if (rb.velocity.x == 0)
        {
            movementSpeed = -movementSpeed;
            localScaleX = -localScaleX;
        }

        //if (hit.collider == null)
        //{
        //    movementSpeed = -movementSpeed;
        //    localScaleX = -localScaleX;
        //}
        //else
        //{
        //    if (rb.velocity.x == 0)
        //    {
        //        movementSpeed = -movementSpeed;
        //        localScaleX = -localScaleX;
        //    }
        //}

        transform.localScale = new Vector3(localScaleX,
            transform.localScale.y, transform.localScale.z);
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

    }
}
