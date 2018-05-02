using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerImage : MonoBehaviour {

    public Image keyboard;
    public Image controller;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetJoystickNames().Length == 1)
        {
            keyboard.gameObject.SetActive(false);
            controller.gameObject.SetActive(true);
        }
        else
        {
            keyboard.gameObject.SetActive(true);
            controller.gameObject.SetActive(false);
        }

    }
}
