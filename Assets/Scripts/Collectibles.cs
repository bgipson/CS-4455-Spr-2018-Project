using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    public GameObject pickle;

    public static string collisionObj;

    public static bool pickle_acquired;
    public static bool tomato_acquired;
    public static bool cheese_acquired;
    public static bool lettuce_acquired;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision");
        if(collision.gameObject.transform.tag == "Pickle")
        {
            pickle_acquired = true;
            collisionObj = "Pickle";
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.transform.tag == "Tomato")
        {
            tomato_acquired = true;
            collisionObj = "Tomato";
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.transform.tag == "Cheese")
        {
            cheese_acquired = true;
            collisionObj = "Cheese";
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.transform.tag == "Lettuce")
        {
            lettuce_acquired = true;
            collisionObj = "Lettuce";
            Destroy(collision.gameObject);
        }

    }

   

}
