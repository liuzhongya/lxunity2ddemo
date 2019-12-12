using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfour : MonoBehaviour {

    public float FourSpeed = 1.0f;
    private Rigidbody2D FourRig;
	// Use this for initialization
	void Start () {
        FourRig = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Gold")
        {
            FourRig.velocity = new Vector2(FourRig.velocity.x, -FourSpeed);
        }
        else if(collision.tag == "Ground")
        {
            FourRig.velocity = new Vector2(FourRig.velocity.x, FourSpeed);
        }
    }
}
