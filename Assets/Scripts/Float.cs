using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

    public GameObject burgie;
    public Transform Anchor;
    public float waterLevel = 0f;
    public float floatThreshold = 2f;
    public float waterDensity = 0.125f;
    public float downForce = 4.0f;
    Rigidbody rb;
    float forceFactor;
    Vector3 floatForce;
    bool isMounted;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		forceFactor = 1.0f - ((transform.position.y) - waterLevel)/floatThreshold;

        if (forceFactor > 0f && isMounted == true)
        {
            downForce = -122f;
            floatForce = -Physics.gravity * (forceFactor - rb.velocity.y * waterDensity);
            floatForce += new Vector3(0f, -downForce, 0f);
            rb.AddForceAtPosition(floatForce, transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime);
            burgie.transform.position = Anchor.position;
        }
        
        if (forceFactor > 0f && isMounted == false)
        {
            floatForce = -Physics.gravity *(forceFactor - rb.velocity.y * waterDensity);
            floatForce += new Vector3(0f, -downForce, 0f);
            rb.AddForceAtPosition(floatForce, transform.position);
            
        }
	}


    private void OnCollisionStay(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            isMounted = true;
        }

    }

}
