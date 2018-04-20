using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour {

    public RawImage Life_1;
    public RawImage Life_2;
    public RawImage Life_3;
    public BurgerController burgerController;

	// Use this for initialization
	void Start () {

        GameObject thePlayer = GameObject.Find("Burgie");
        burgerController = thePlayer.GetComponent<BurgerController>();
        //burgerController.health -= 10.0f;

        Life_1.enabled = false;
        Life_2.enabled = false;
        Life_3.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(burgerController.health == 3)
        {
            Life_1.enabled = true;
            Life_2.enabled = true;
            Life_3.enabled = true;
        }
        else if (burgerController.health == 2)
        {
            Life_1.enabled = true;
            Life_2.enabled = true;
            Life_3.enabled = false;
        }
        else if (burgerController.health == 1)
        {
            Life_1.enabled = true;
            Life_2.enabled = false;
            Life_3.enabled = false;
        }
        else 
        {
            Life_1.enabled = false;
            Life_2.enabled = false;
            Life_3.enabled = false;
        }

    }
}
