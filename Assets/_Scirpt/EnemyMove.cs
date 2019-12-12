using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {


    public float EnemySpeed = 2.0f;
    private Rigidbody2D EnemyRig;
    private BoxCollider2D enemyboxcollider;
    public PlayerMove playermove;
    private Animator Enemyani;
    private int Count = 0;


    [HideInInspector]
    public bool facingRight = false;//角色是否朝向右侧

                                   // Use this for initialization
    void Start () {
        EnemyRig = GetComponent<Rigidbody2D>();
        playermove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        Enemyani = GetComponent<Animator>();
        enemyboxcollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            playermove.OnDamage(1);
        }
        else if(collision.gameObject.tag == "Guan")
        {
            Count = Count + 1;
            if (Count == 1)
            {
                facingRight = true;
                flip();
            }
            else
            {
                facingRight = false;
                flip();
                Count = 0;
            }
        }
    }

    private void Move()
    {
        EnemyRig.velocity = new Vector2(-EnemySpeed, EnemyRig.velocity.y);
        if(facingRight==true)
        {
            EnemyRig.velocity = new Vector2(EnemySpeed, EnemyRig.velocity.y);
        }
    }

    public void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            VideoController.Instance.PlaySound("踩敌人");
            Enemyani.SetBool("IsDead", true);
            Destroy(enemyboxcollider);
        }
        else if(collision.tag=="Bullet"||collision.tag=="Finsh")
        {
            Destroy(gameObject);
        }
    }
}
