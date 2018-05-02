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
    AudioSource audio;
    public AudioClip water;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isMounted == true)
        {
            water_audio_on();
            Debug.Log("waterrr");
        }
        else
            water_audio_off();
    }

    // Update is called once per frame
    void FixedUpdate () {
		forceFactor = 1.0f - ((transform.position.y) - waterLevel)/floatThreshold;
        
        if (forceFactor > 0f && isMounted == true && transform.position.z > -682f)
        {
            downForce = -122f;
            floatForce = -Physics.gravity * (forceFactor - rb.velocity.y * waterDensity);
            floatForce += new Vector3(0f, -downForce, 0f);
            rb.AddForceAtPosition(floatForce, transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime);
            burgie.transform.position = Anchor.position;
            
        }

        if (forceFactor > 0f && isMounted == true && transform.position.z < -682f)
        {
            downForce = -122f;
            floatForce = -Physics.gravity * (forceFactor - rb.velocity.y * waterDensity);
            floatForce += new Vector3(0f, -downForce, 0f);
            rb.AddForceAtPosition(floatForce, transform.position);
            
            //transform.Translate(Vector3.forward * Time.deltaTime);
            //burgie.transform.position = Anchor.position;
        }

        if (forceFactor > 0f && isMounted == false && transform.position.z > -682f)
        {
            floatForce = -Physics.gravity *(forceFactor - rb.velocity.y * waterDensity);
            floatForce += new Vector3(0f, -downForce, 0f);
            rb.AddForceAtPosition(floatForce, transform.position);
            
        }
        if (forceFactor > 0f && isMounted == false && transform.position.z < -682f)
        {
            transform.position = new Vector3(transform.position.x, 76.343f, transform.position.z);

        }
    }

    public void water_audio_on()
    {
        audio.clip = water;
        audio.Play();
        audio.loop = true;
    }

    public void water_audio_off()
    {
        audio.clip = water;
        audio.Stop();
    }

    private void OnCollisionStay(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            isMounted = true;

        }

    }

}
