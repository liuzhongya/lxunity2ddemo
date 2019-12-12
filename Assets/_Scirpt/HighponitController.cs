using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighponitController : MonoBehaviour {


    private Rigidbody2D HighPonitRig;
    private float DownSpeed=1.0f;
    public bool Down = false;
	// Use this for initialization
	void Start ()
    {
        HighPonitRig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            HighPonitRig.velocity = new Vector2(HighPonitRig.velocity.x, -DownSpeed);
           
        }
        else if(collision.tag=="Ground")
        {
            DownSpeed = 0;
            Down = true;
        }
    }
}
