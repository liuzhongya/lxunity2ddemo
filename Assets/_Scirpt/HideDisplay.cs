using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDisplay : MonoBehaviour {

    private BoxCollider2D HideCollider;
    public GameObject Hidedisplay1;
    public GameObject Hidedisplay2;
    // Use this for initialization
    void Start () {
        HideCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            HideCollider.isTrigger = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Hidedisplay1.SetActive(true);
            Hidedisplay2.SetActive(true);
        }
    }
}
