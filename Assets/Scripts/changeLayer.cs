using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLayer : MonoBehaviour {

    public float ymin = 82f;

	// Update is called once per frame
	void Update () {
        //Debug.LogError(this.transform.position.y);
        if (this.transform.position.y <= ymin) {
            this.gameObject.layer = LayerMask.NameToLayer("Default");
        }
	}
}
