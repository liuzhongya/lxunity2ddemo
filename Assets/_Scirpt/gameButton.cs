using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameButton : MonoBehaviour {


    public GameObject Pause;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //暂停功能
    public void Pausegame()
    {
        Time.timeScale = 0;
        Pause.SetActive(true);
    }
    //继续游戏
    public void OnGame()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
    }
    //返回游戏
    public void ReturnGame()
    {
        SceneManager.LoadScene("StartGame");
    }
}
