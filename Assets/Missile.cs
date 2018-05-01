using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    
    public float speed;
    private Rigidbody rb;
    private Transform Target;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 50f;
    }

    private void FixedUpdate()
    {
       if(Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        

    }

    void HitTarget()
    {
        Destroy(gameObject);
    }

    public void Seek(Transform _target)
        {
        Target = _target;
        }


    

    //IEnumerator Example()
    //{
    //    print(Time.time);
    //    yield return new WaitForSeconds(5);
    //    print(Time.time);
    //}

}
