using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFall : MonoBehaviour {

    private Rigidbody2D groundRig;
    private float FallSpeed = 2.0f;

	// Use this for initialization
	void Start () {
        groundRig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            groundRig.velocity = new Vector2(groundRig.velocity.x, -FallSpeed);
        }
        else if(collision.tag=="Finish")
        {
            Destroy(gameObject);
        }
    }
}
