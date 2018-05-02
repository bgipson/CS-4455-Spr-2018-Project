using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_impact : MonoBehaviour {

    AudioSource audio;
    int count;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (count == 0)
        {
            audio.Play();
        }
        count++;

    }

}
