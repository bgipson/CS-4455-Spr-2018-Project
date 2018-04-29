using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    public bool check = false;
    public void OnTriggerStay(Collider other) {
        check = true;
    }
    public void OnTriggerExit(Collider other) {
        check = false;
    }
}
