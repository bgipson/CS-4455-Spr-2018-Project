using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour {
    //Toggle through collected abilities & display
    //in the array, position 0 is pickles, 1 is cheese, 2 is tomato, and 3 is lettuce
    public int powerup_num;
    public ParticleSystem particle;
    public List<Texture> PowerupSprites;
    public RawImage PowerupIndicator;
    public RawImage PowerupIndicator2;
    public RawImage PowerupIndicator3;
    public RawImage PowerupIndicator4;
    public GameObject ProgressBar;
    public GameObject dynamicProgressBar;
    public DoAction shoot;
    private Transform progressbarimage;
    public bool pickle_enabled;
    public bool cheese_enabled;
    public bool tomato_enabled;
    public bool lettuce_enabled;
    public bool default_enabled;
    public RawImage BG1;
    public RawImage BG2;
    public RawImage BG3;
    public RawImage BG4;


    void Start() {
        //powerup = Powerup.Default;
        default_enabled = true;
        powerup_num = 0;
    }

    void Update() {
        ReadInput();

        Decode_Powerups();

        if (pickle_enabled)
        {
            //Debug.Log(shoot.power);
            //PowerupIndicator.texture = PowerupSprites[0];
            ProgressBar.SetActive(true);
            BG1.gameObject.SetActive(true);
            BG2.gameObject.SetActive(false);
            BG3.gameObject.SetActive(false);
            BG4.gameObject.SetActive(false);
            if (Collectibles.pickle_acquired)
            {
                dynamicProgressBar.GetComponent<Image>().fillAmount = (shoot.power - 10f) / 70f;
            }
        }

        else if (cheese_enabled)
        {
            ProgressBar.SetActive(false);
            BG1.gameObject.SetActive(false);
            BG2.gameObject.SetActive(true);
            BG3.gameObject.SetActive(false);
            BG4.gameObject.SetActive(false);
        }

        else if (tomato_enabled)
        {
            ProgressBar.SetActive(false);
            BG1.gameObject.SetActive(false);
            BG2.gameObject.SetActive(false);
            BG3.gameObject.SetActive(true);
            BG4.gameObject.SetActive(false);
        }
        else if (lettuce_enabled)
        {
            ProgressBar.SetActive(false);
            BG1.gameObject.SetActive(false);
            BG2.gameObject.SetActive(false);
            BG3.gameObject.SetActive(false);
            BG4.gameObject.SetActive(true);

        }
        else if (default_enabled)
        {
            ProgressBar.SetActive(false);
            BG1.gameObject.SetActive(true);
        }

        if (Collectibles.pickle_acquired)
        {
            if (PowerupIndicator.texture != PowerupSprites[0]) PowerupIndicator.texture = PowerupSprites[0];
        }
        if (Collectibles.cheese_acquired)
        {
            if (PowerupIndicator2.texture != PowerupSprites[1]) PowerupIndicator2.texture = PowerupSprites[1];
        }
        if (Collectibles.tomato_acquired)
        {
            if (PowerupIndicator3.texture != PowerupSprites[2]) PowerupIndicator3.texture = PowerupSprites[2];
        }
        if (Collectibles.lettuce_acquired)
        {
            if (PowerupIndicator4.texture != PowerupSprites[3]) PowerupIndicator4.texture = PowerupSprites[3];
        }

    }



    private void Decode_Powerups()
    {
        if (powerup_num == 1)
            pickle_enabled = true;
        else if (powerup_num == 2)
            cheese_enabled = true;
        else if (powerup_num == 3)
            tomato_enabled = true;
        else if (powerup_num == 4)
            lettuce_enabled = true;
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
            powerup_num = 1;
            Reset_PowerUps();
            pickle_enabled = true;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            //powerup = Powerup.Cheese;
            powerup_num = 2;
            Reset_PowerUps();
            cheese_enabled = true;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            //powerup = Powerup.Tomato;
            powerup_num = 3;
            Reset_PowerUps();
            tomato_enabled = true;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            //powerup = Powerup.Lettuce;
            powerup_num = 4;
            Reset_PowerUps();
            lettuce_enabled = true;
        }

        if(Input.mouseScrollDelta.y > 0f || Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            Reset_PowerUps();
            if (powerup_num < 4)
                powerup_num++;
            //Debug.Log(powerup_num);
        }

        if (Input.mouseScrollDelta.y < 0f || Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            Reset_PowerUps();
            if (powerup_num > 1)
                powerup_num--;
            //Debug.Log(powerup_num);
        }


    }



	
}


