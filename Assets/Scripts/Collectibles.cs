using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    public GameObject pickle;
    public static bool pickle_activated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.tag == "Pickle")
        {
            pickle_activated = true;
            Destroy(collision.gameObject);
        }
    }

}
