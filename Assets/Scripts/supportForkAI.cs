using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supportForkAI : MonoBehaviour {
    public void toggleMove(int val) {
        if (val == 0) {
            mainAI.toggleMove(false);
        } else {
            mainAI.toggleMove(true);
        }
        
    }

    public void toggleRotate(int val) {
        if (val == 0) {
            mainAI.toggleRotate(false);
        } else {
            mainAI.toggleRotate(true);
        }

    }

    ForkAI mainAI;
    // Use this for initialization
    void Start () {
		mainAI = GetComponentInParent<ForkAI>();
    }
}
