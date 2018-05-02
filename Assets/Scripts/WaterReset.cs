using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterReset : MonoBehaviour {
    public GameObject resetPoint;
    public float resetTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool resetingPlayer = false;
    IEnumerator resetPlayer(float time, GameObject other) {
        print("AY");
        if (!resetingPlayer) {
            resetingPlayer = true;
            yield return new WaitForSeconds(time);
            other.transform.position = resetPoint.transform.position;
            resetingPlayer = false;
        }
    }

    public void OnTriggerEnter(Collider other) {
        print("AY");
        if (other.gameObject.tag == "Player") {
            StartCoroutine(resetPlayer(resetTime, other.gameObject));
        }
    }
}
