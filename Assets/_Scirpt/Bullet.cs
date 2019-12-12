using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject Boom;
    private float AttackSpeed = 20f;
    private PlayerMove playermove;

	// Use this for initialization
	void Start () {
        playermove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 0.2f);
        if (playermove.facingRight == true) 
            transform.Translate(new Vector2(AttackSpeed * Time.deltaTime,0));
        else
            transform.Translate(new Vector2(-AttackSpeed * Time.deltaTime, 0));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            Destroy(gameObject);
            Instantiate(Boom, transform.position, Quaternion.identity);
        }
    }
}
