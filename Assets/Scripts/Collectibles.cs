using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    public GameObject pickle;
    public PowerUpManager powerUpManager;

    public static string collisionObj;

    public static bool pickle_acquired;
    public static bool tomato_acquired;
    public static bool cheese_acquired;
    public static bool lettuce_acquired;
    AudioSource audio;
    public AudioClip collect;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool getCheese() {
        return cheese_acquired;
    }

    public bool getTomato() {
        return tomato_acquired;
    }

    public bool getLettuce() {
        return lettuce_acquired;
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if(collision.gameObject.transform.tag == "Pickle")
        {
            
            pickle_acquired = true;
            collisionObj = "Pickle";
            audio.clip = collect;
            audio.Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.transform.tag == "Cheese")
        {
            Debug.Log("Cheese");
            cheese_acquired = true;
            collisionObj = "Cheese";
            audio.clip = collect;
            audio.Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.transform.tag == "Tomato")
        {
            tomato_acquired = true;
            collisionObj = "Tomato";
            audio.clip = collect;
            audio.Play();
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.transform.tag == "Lettuce")
        {
            lettuce_acquired = true;
            collisionObj = "Lettuce";
            audio.clip = collect;
            audio.Play();
            Destroy(collision.gameObject);
        }

    }

   

}
