using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndNextGame : MonoBehaviour {


    public HighponitController HighPonit;
	// Use this for initialization
	void Start () {
        HighPonit = GetComponent<HighponitController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"&&HighPonit.Down==true)
        {
            SceneManager.LoadScene("NextGame");
        }
    }
}
