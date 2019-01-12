using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingPlayer : MonoBehaviour {

    private GameObject player;


	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
		if(player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
