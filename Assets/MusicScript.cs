using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    public AudioClip newsMusic;
    public AudioClip gameMusic;
    public AudioClip gameMusic2;

    public AudioSource source;

    public void PlayMusic(int i) {
        if (i == 1) {
            source.clip = gameMusic;
            source.Play();
        }
        if (i == 2) {
            source.clip = gameMusic2;
            source.Play();
        }
        if (i == 3)
        {
            source.clip = newsMusic;
            source.Play();
        }
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
