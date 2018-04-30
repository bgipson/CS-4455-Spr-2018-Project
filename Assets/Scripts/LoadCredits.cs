using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour {

	public void StartCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("Controls");
    }
}
