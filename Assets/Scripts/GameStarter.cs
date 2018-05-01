using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class GameStarter : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadControlsFromPause()
    {
        //canvasGroup.interactable = true;
        //canvasGroup.blocksRaycasts = true;
        //canvasGroup.alpha = 1f;
        //Time.timeScale = 0f;
    }

    // //Load scene by index
    //public void LoadByIndex(int sceneIndex)
    //{
    //    SceneManager.LoadScene(sceneIndex);
    //}
}
