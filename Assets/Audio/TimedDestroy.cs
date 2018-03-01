using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys an object after a set amount of time
public class TimedDestroy : MonoBehaviour {
    public float waitTime = 1;
    bool startOnAwake = false;
	// Use this for initialization
	void Start () {
		if (startOnAwake) StartCoroutine(timedDestroy());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startTimer() {
        StartCoroutine(timedDestroy());
    }

    IEnumerator timedDestroy() {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
