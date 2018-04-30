using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV_AI : MonoBehaviour {

    public Transform player;
    public float maxAngle;
    public float maxRadius;
    private bool IsinFOV;

    private void Update()
    {
        IsinFOV = InFOV(transform, player, maxAngle, maxRadius);
        
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * -transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * -transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);
        Vector3 direction = (player.position - transform.position).normalized * maxRadius;
        direction.y *= 0;
        if (IsinFOV == false)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, direction);
        }

        if (IsinFOV == true)
        {
            Debug.Log("Detected");
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, direction);
        }

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, -transform.forward * maxRadius);
    }

    public static bool InFOV(Transform FOV_Emitter, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlap = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(FOV_Emitter.position, maxRadius, overlap);
        for(int i=0;i<count + 1; i++)
        {
            if(overlap[i]!=null)
            {
                
                if(overlap[i].transform == target)
                {
                    
                    Vector3 direction = (target.position - FOV_Emitter.position).normalized;
                    direction.y *= 0;
                    float angle = Vector3.Angle(-FOV_Emitter.forward, direction);
                    
                    
                    if(angle <maxAngle)
                    {
                        //Ray ray = new Ray(FOV_Emitter.position, target.position);
                        //RaycastHit hit;
                        //if (Physics.Raycast(ray, out hit, maxRadius))
                        //{
                        //    if (hit.transform == target)
                        //        return true;
                        //}
                        return true;
                    }
                }
            }
        }
        return false;
    }

}
