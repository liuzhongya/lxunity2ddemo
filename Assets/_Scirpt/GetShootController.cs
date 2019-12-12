using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShootController : MonoBehaviour {

    private PlayerMove player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            VideoController.Instance.PlaySound("吃到蘑菇或花");
            player.isAttack = true;
            Destroy(gameObject);
        }
    }
}
