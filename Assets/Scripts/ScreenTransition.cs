using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour {
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fadeIn() {
        animator.SetTrigger("FadeIn");
        print("FADING IN");
    }

    public void fadeInToLevel(int level) {
        levelToLoad = level;
        fadeIn();
    }

    public int levelToLoad = 0;
    public void loadLevel() {
        SceneManager.LoadScene(levelToLoad);
    }

    public void fadeOut() {
        animator.SetTrigger("FadeOut");
        print("FADE OUT");
    }
}
