using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkAI : MonoBehaviour {

    public float range = 15f;
    public Transform target;
    public float distanceToTarget;
    public float turnSpeed = 10f;
    public ParticleSystem Circle;
   // public GameObject Triangle;
    //public Material[] mats;
    //var main = Triangle.main;
    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.01f);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Circle.startColor = new Color(0f, 0.5f, 1f);
//Triangle.GetComponent<Renderer>().material = mats[1];
            return;
        }

        Circle.startColor = new Color(1f,0f,0f);
        //Triangle.startColor = new Color(1f, 0f, 0f);
        
        Vector3 targetDir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
       // Triangle.GetComponent<Renderer>().material = mats[0];
        //Triangle.startRotation = gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
        


    }

    void UpdateTarget()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Player");
        
        float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);
        if (distanceToEnemy <= range)
        {
            target = enemy.transform;
        }
        else target = null;    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
