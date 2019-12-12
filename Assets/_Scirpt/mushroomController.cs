using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomController : MonoBehaviour
{
    public GameObject mush;
    public GameObject Get;
    private Animator Anim;
    private BoxCollider2D mushCollider;
	// Use this for initialization
	void Start ()
    {
        Anim = GetComponent<Animator>();
        mushCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            VideoController.Instance.PlaySound("顶到蘑菇，花或星");
            Anim.SetBool("Eat", true);
            Instantiate(mush, Get.transform.position, Quaternion.identity);
            Destroy(mushCollider);
        }
    }
}
