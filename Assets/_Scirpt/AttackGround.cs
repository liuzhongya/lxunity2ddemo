using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGround : MonoBehaviour {

    private PlayerMove playermove;

	// Use this for initialization
	void Start () {
        playermove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag=="Player")
        {
            VideoController.Instance.PlaySound("死亡1");
            playermove.anim.SetBool("Die", true);
            Destroy(playermove.PlayerCollider);
        }
    }
}
