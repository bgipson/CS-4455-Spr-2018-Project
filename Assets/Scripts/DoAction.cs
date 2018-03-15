using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAction : MonoBehaviour
{

    public GameObject Start_position;
    public Rigidbody bullet;
    public float power;
    public PowerUpManager powerUpManager;
    Animator animator;
    //float time = 0f;
   
    void Start()
    {
        power = 30f;
        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        
        if (Input.GetButton("Fire1")) //button pressed
        {
            if (Collectibles.pickle_acquired && powerUpManager.pickle_enabled) //pickle selected
            {
                Debug.Log("Pressed");
                if (power < 150f)
                {
                    power += 2f;
                }
            }
            else if (Collectibles.cheese_acquired && powerUpManager.cheese_enabled) //Collectibles.cheese_acquired && 
            {
                //super jump
                animator.SetBool("HighJump", true);
            }
            else if (Collectibles.tomato_acquired && powerUpManager.tomato_enabled) //Collectibles.tomato_acquired &&
            {
                //squish enabled
                animator.SetBool("Squished", true);
            }
            else if (Collectibles.lettuce_acquired && powerUpManager.lettuce_enabled)
            {
                //shield enabled
            }

        }

        if (Input.GetButtonUp("Fire1")) //button let go
        {
            if (Collectibles.pickle_acquired && powerUpManager.pickle_enabled) //pickle selected
            {
                Shooting();
            }
            //else if (Collectibles.cheese_acquired && powerUpManager.cheese_enabled)
            //{
            //    //super jump
            //}
            else if (Collectibles.tomato_acquired && powerUpManager.tomato_enabled) //Collectibles.tomato_acquired && 
            {
                //squish disabled
                animator.SetBool("Squished", false);
            }
            else if (Collectibles.lettuce_acquired && powerUpManager.lettuce_enabled)
            {
                //shield disabled
            }
        }
        
        
    }

    public void Shooting()
    {
        Rigidbody instantiated_projectile = Instantiate(bullet, Start_position.transform.position, Start_position.transform.rotation);
        instantiated_projectile.AddForce(Start_position.transform.forward * power/10 + new Vector3(0f, 5f/10, 0f), ForceMode.Impulse);
        power = 30f;
       
    }
    
}
