using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkAI : MonoBehaviour {

    public float range = 15f;
    public Transform target;
    public float distanceToTarget;
    public float turnSpeed = 10f;
    public ParticleSystem Circle;

    public Transform mainFork;

    Animator animator;
    public bool movingToward = false;
    bool rotateToward = true;

   // public GameObject Triangle;
    //public Material[] mats;
    //var main = Triangle.main;
    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.01f);
        animator = GetComponentInChildren<Animator>();    
	}

    Vector3 targetPos;
	// Update is called once per frame
	void Update () {
        if (animator.GetBool("AreaClear"))
        {
            Circle.startColor = new Color(0f, 0.5f, 1f);
        } else {
            Circle.startColor = new Color(1f, 0f, 0f);
        }

        if (movingToward) {
            mainFork.transform.position = Vector3.Lerp(mainFork.transform.position, 
                new Vector3(targetPos.x, mainFork.transform.position.y, targetPos.z), 0.1f);
        } else {
            mainFork.transform.localPosition = Vector3.Lerp(mainFork.transform.localPosition,
               Vector3.zero, 0.1f);
        }

        
        if (rotateToward) {
            Vector3 targetDir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(targetDir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    Vector3 targetRotation;

    void UpdateTarget()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Player");
        
        float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);
        if (distanceToEnemy <= range) {
            animator.SetBool("AreaClear", false);
            animator.SetBool("Attacking", true);
            if (movingToward == false) {
                target = enemy.transform;
                targetPos = enemy.transform.position;
            }
        } else {
            animator.SetBool("AreaClear", true);
        }
     }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        
    }

    public void toggleMove(bool val) {
        movingToward = val;
    }

    public void toggleRotate(bool val) {
        rotateToward = val;
    }

}
