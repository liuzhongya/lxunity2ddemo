using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {


    public Button StartButton;
    public Button ExitButton;
    public Button SetButton;
    public Button ReturnButton;
    public GameObject SetImage;

     
	// Use this for initialization
	void Start () {
        StartButton.onClick.AddListener(StartGame);
        ExitButton.onClick.AddListener(ExitGame);
        SetButton.onClick.AddListener(Set);
        ReturnButton.onClick.AddListener(Return);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //开始游戏
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    //退出游戏
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void Set()
    {
        SetImage.SetActive(true);
    }
    public void Return()
    {
        SetImage.SetActive(false);
    }
}
