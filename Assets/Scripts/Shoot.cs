using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject Start_position;
    public Rigidbody bullet;
    float power;
    // Use this for initialization
    void Start()
    {
        power = 30f;
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetButton("Fire1"))
        {

            Debug.Log("Pressed");
            if (power < 150f)
            {
                
                power += 2f;

            }
            Debug.Log(power);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Shooting();
        }
    }

    public void Shooting()
    {
        Rigidbody instantiated_projectile = Instantiate(bullet, Start_position.transform.position, Start_position.transform.rotation);

        //instantiated_projectile.velocity = Start_position.transform.forward*10f + new Vector3(0f, power, 0f);
        instantiated_projectile.AddForce(Start_position.transform.forward * power/10 + new Vector3(0f, 5f/10, 0f), ForceMode.Impulse);
        power = 30f;
        Debug.Log("Released");
    }
    
}
