using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public Transform Target;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = Target.transform.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = new Vector3(0, 0, rotateAmount * rotateSpeed);
        rb.velocity = transform.up * speed;
    }

}
