using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter : MonoBehaviour {

    public GameObject[] Fire = new GameObject[4];
    float timer;
    float random;

    private void Start()
    {
        Fire[0].SetActive(false);
        Fire[1].SetActive(false);
        Fire[2].SetActive(false);
        Fire[3].SetActive(false);
        //InvokeRepeating("Alternate1", 0f, 4f);
        //InvokeRepeating("Alternate2", 2f, 4f);
    }

    private void Update()
    {


        if (timer >= 1f)
        {
            //Debug.Log("Change");


            if (random == 1)
                Alternate1();  //Invoke("Alternate1", 0f);
            else if (random == 2)
                Alternate2();  //Invoke("Alternate2", 0f);
            else if (random == 3)
                Alternate3();  //Invoke("Alternate3", 0f);
            else if (random == 4)
                Alternate4();  //Invoke("Alternate4", 0f);
            timer = 0f;

        }
        if (timer == 0f)
        {
            random = Random.Range(1, 5);
            //Debug.Log(random);
        }
        timer = timer + Time.deltaTime;
    }

    void Alternate1()
    {
        //Debug.Log("Alternate1");
        Fire[0].SetActive(true);
        Fire[1].SetActive(false);
        Fire[2].SetActive(false);
        Fire[3].SetActive(false);
    }
    void Alternate2()
    {
        //Debug.Log("Alternate2");
        Fire[0].SetActive(false);
        Fire[1].SetActive(true);
        Fire[2].SetActive(false);
        Fire[3].SetActive(false);
    }
    void Alternate3()
    {
        //Debug.Log("Alternate3");
        Fire[0].SetActive(false);
        Fire[1].SetActive(false);
        Fire[2].SetActive(true);
        Fire[3].SetActive(false);
    }
    void Alternate4()
    {
        //Debug.Log("Alternate4");
        Fire[0].SetActive(false);
        Fire[1].SetActive(false);
        Fire[2].SetActive(false);
        Fire[3].SetActive(true);
    }
}
