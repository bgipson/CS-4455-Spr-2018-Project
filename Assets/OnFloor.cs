using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFloor : MonoBehaviour {

    public bool isPlayeronfloor;
    void Start()
    {
        isPlayeronfloor = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isPlayeronfloor = true;
    }
}
