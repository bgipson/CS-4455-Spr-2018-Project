using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // //Load scene by index
    //public void LoadByIndex(int sceneIndex)
    //{
    //    SceneManager.LoadScene(sceneIndex);
    //}
}
