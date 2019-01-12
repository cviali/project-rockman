using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
    public int count = 0;
	// Use this for initialization
	void Start () {
		
	}

    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (count == 0)
    //    {
    //        GetComponent<BoxCollider2D>().isTrigger = true;
    //        GetComponent<SpriteRenderer>().enabled = false;
    //        count = count + 1;
    //    }
    //}
    //void OnTriggerExit2D(Collider2D col)
    //{
    //        GetComponent<BoxCollider2D>().isTrigger = false;
    //        GetComponent<SpriteRenderer>().enabled = true;x; 
    //}
}
