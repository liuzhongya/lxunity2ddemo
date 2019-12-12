using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour {


    public static VideoController Instance;  //设置单例
    public AudioSource MusicPlayer;
    public AudioSource SoundPlayer;
	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //播放背景音乐
    public void PlayMusic(string name)
    {
        if(MusicPlayer.isPlaying==false)
        {
            AudioClip clip = Resources.Load<AudioClip>(name);
            MusicPlayer.clip = clip;
            MusicPlayer.Play();

        }
    }

    //停止播放背景音乐
    public void  StopPlay()
    {
        MusicPlayer.Stop();
    }

    //播放音效
    public void PlaySound(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        SoundPlayer.PlayOneShot(clip);
    }
}
