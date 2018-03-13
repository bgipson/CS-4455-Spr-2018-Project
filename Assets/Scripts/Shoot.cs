using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject Start_position;
    public Rigidbody bullet;
    public float power;
    public PowerUpManager powerUpManager;
    //float time = 0f;
   
    void Start()
    {
        power = 30f;
    }

    
    void FixedUpdate()
    {
        
            if (Input.GetButton("Fire1") && Collectibles.pickle_acquired == true && powerUpManager.pickle_enabled == true)
            {

                Debug.Log("Pressed");
                if (power < 150f)
                {

                    power += 2f;

                }
                
            }
            if (Input.GetButtonUp("Fire1") && Collectibles.pickle_acquired == true && powerUpManager.pickle_enabled == true)
            {
                Shooting();
            }
        
    }

    public void Shooting()
    {
        Rigidbody instantiated_projectile = Instantiate(bullet, Start_position.transform.position, Start_position.transform.rotation);
        instantiated_projectile.AddForce(Start_position.transform.forward * power/10 + new Vector3(0f, 5f/10, 0f), ForceMode.Impulse);
        power = 30f;
       
    }
    
}
