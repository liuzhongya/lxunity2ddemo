using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour {

    private PlayerMove player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.ChangGold(5);
            VideoController.Instance.PlaySound("金币");
            Destroy(gameObject);
        }
    }
}
