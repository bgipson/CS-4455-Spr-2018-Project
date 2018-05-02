using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnFallenItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
        respawnPos = gameObject.transform.position;
        respawnRot = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 respawnPos;
    public Quaternion respawnRot;

    public void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Floor") {
            transform.position = respawnPos;
            transform.rotation = respawnRot;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
