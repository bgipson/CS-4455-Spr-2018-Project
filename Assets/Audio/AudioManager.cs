using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playAudio(AudioClip clip) {
        GameObject aud = new GameObject();
        aud.transform.parent = gameObject.transform;
        AudioSource source = aud.AddComponent<AudioSource>();
        TimedDestroy destroyer = aud.AddComponent<TimedDestroy>();
        destroyer.waitTime = clip.length;
        source.clip = clip;
        source.Play();
        destroyer.startTimer();
        
    }
}
