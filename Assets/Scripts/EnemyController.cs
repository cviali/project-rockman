using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //destroy enemy and bullet
        CekEnemy(col.gameObject);
        Destroy(col.gameObject);
    }

    void CekEnemy(GameObject obj)
    {
        if (obj.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
