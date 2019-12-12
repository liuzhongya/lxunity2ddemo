using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropContoller : MonoBehaviour {

    public GameObject SmallGold;
    public GameObject Get;
    private PlayerMove playermove;
    private BoxCollider2D PropCollider;
    private int Count = 0;
    // Use this for initialization
    void Start () {
        playermove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"&&Count<=5)
        {
            Count++;
            playermove.ChangGold(3);
            Instantiate(SmallGold, Get.transform.position, Quaternion.identity);
            if (Count > 5)
                Destroy(PropCollider);
        }
    }
}
