﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour {

	public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
