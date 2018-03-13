using System;
using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour {
    //Toggle through collected abilities & display
    //in the array, position 0 is pickles, 1 is cheese, 2 is tomato, and 3 is lettuce

    public List<Texture> PowerupSprites;
    public RawImage PowerupIndicator;
    public GameObject ProgressBar;
    public GameObject dynamicProgressBar;
    public Shoot shoot;
    private Transform progressbarimage;
    public  bool pickle_enabled;
    public  bool cheese_enabled;
    public  bool tomato_enabled;
    public  bool lettuce_enabled;
    public  bool default_enabled;

    //public enum Powerup
    //{
    //    Default,
    //    Pickle,
    //    Cheese,
    //    Tomato,
    //    Lettuce
    //}
    //public Powerup powerup;

	void Start() {
        //powerup = Powerup.Default;
        default_enabled = true;
	}

	void Update() {
        ReadInput();
        //if (pickle_enabled) //powerup == Powerup.Pickle)
        //    transform.GetComponent<Shoot>().enabled = true;
        //else
        //    transform.GetComponent<Shoot>().enabled = false;

        //switch(powerup)
        //{
        //    case Powerup.Pickle:
        //        PowerupIndicator.texture = PowerupSprites[0];
        //        ProgressBar.SetActive(true);
        //        dynamicProgressBar.GetComponent<Image>().fillAmount = (shoot.power - 30f)/120f;
        //        pickle_enabled = true;
        //        break;
        //    case Powerup.Cheese:
        //        ProgressBar.SetActive(false);
        //        PowerupIndicator.texture = PowerupSprites[1];
        //        cheese_enabled = true;
        //        break;
        //    case Powerup.Tomato:
        //        ProgressBar.SetActive(false);
        //        PowerupIndicator.texture = PowerupSprites[2];
        //        tomato_enabled = true;
        //        break;
        //    case Powerup.Lettuce:
        //        ProgressBar.SetActive(false);
        //        PowerupIndicator.texture = PowerupSprites[3];
        //        lettuce_enabled = true;
        //        break;
        //    case Powerup.Default:
        //        ProgressBar.SetActive(false);
        //        PowerupIndicator.texture = PowerupSprites[4];
        //        break;
        //}



        if (pickle_enabled)
        {
            Debug.Log(shoot.power);
            PowerupIndicator.texture = PowerupSprites[0];
            ProgressBar.SetActive(true);
            dynamicProgressBar.GetComponent<Image>().fillAmount = (shoot.power - 30f) / 120f;
        }

        else if (cheese_enabled)
        {
            ProgressBar.SetActive(false);
            PowerupIndicator.texture = PowerupSprites[1];
        }

        else if (tomato_enabled)
        {
            ProgressBar.SetActive(false);
            PowerupIndicator.texture = PowerupSprites[2];
        }
        else if (lettuce_enabled)
        {
            ProgressBar.SetActive(false);
            PowerupIndicator.texture = PowerupSprites[3];
        }
        else if (default_enabled)
        {
            ProgressBar.SetActive(false);
            PowerupIndicator.texture = PowerupSprites[4];
        }
        
    }

    private void Reset_PowerUps()
    {
        pickle_enabled = false;
        cheese_enabled = false;
        tomato_enabled = false;
        lettuce_enabled = false;
        default_enabled = false;
    }

    private void ReadInput()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //powerup = Powerup.Pickle;
            Reset_PowerUps();
            pickle_enabled = true;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            //powerup = Powerup.Cheese;
            Reset_PowerUps();
            cheese_enabled = true;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            //powerup = Powerup.Tomato;
            Reset_PowerUps();
            tomato_enabled = true;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            //powerup = Powerup.Lettuce;
            Reset_PowerUps();
            lettuce_enabled = true;
        }

    }



	
}


