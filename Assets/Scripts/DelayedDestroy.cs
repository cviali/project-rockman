using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour {

    public float delay = 1f;

	// Use this for initialization
	void Start () {
        Invoke("Destroy", delay);
	}

    // Update is called once per frame
    void Destroy() {
        Destroy(gameObject);
	}
}
