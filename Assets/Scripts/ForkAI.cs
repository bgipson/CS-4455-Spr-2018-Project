using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkAI : MonoBehaviour {

    public float range = 15f;
    public Transform target;
    public float distanceToTarget;
    public float turnSpeed = 10f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;

       
        Vector3 targetDir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f); 


       
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
