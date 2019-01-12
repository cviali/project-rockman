using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blipping : MonoBehaviour {
    public float BlipTime = 1f;
    float deltaTime = 0;
    
	// Update is called once per frame
	void Update () {
        deltaTime += Time.deltaTime;
        if(deltaTime >= BlipTime)
        {
            SpriteRenderer sp = GetComponent<SpriteRenderer>();
            if(sp.color.a == 0)
            {
                sp.color = Color.white;
            } else
            {
                Color newColor = Color.white;
                newColor.a = 0;
                sp.color = newColor;
            }
        }
	}
}
