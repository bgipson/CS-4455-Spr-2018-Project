using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    //https://www.youtube.com/watch?v=_nRzoTzeyxU

    public Text dialogueText;
    public Animator animator;
    int countdown = 100;
    public int timer;
    public bool doCountdown;
    private Queue<string> sentences;
    public PowerUpManager powerUpManager;

    void Start () {
        sentences = new Queue<string>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
	}

    private void Update()
    {

        //"you've collected the ____!"
        if (doCountdown)
        {
            if (timer == 0)
            {
                DisplayNextSentence();
                timer = countdown;
                doCountdown = false;
            }
            else timer--;
        }

        //"Press __ to activate your power"
        if (sentences.Count == 1)
        {
            if (Collectibles.collisionObj == "Pickle")
            {
                if (powerUpManager.pickle_enabled)   //Input.GetKey(KeyCode.Alpha1))
                {
                    DisplayNextSentence();
                }
            }
            else if (Collectibles.collisionObj == "Cheese")
            {
                if (powerUpManager.cheese_enabled)
                {
                    DisplayNextSentence();
                }
            }
            else if (Collectibles.collisionObj == "Tomato")
            {
                if (powerUpManager.tomato_enabled)
                {
                    DisplayNextSentence();
                }
            }
            else if (Collectibles.collisionObj == "Lettuce")
            {
                if (powerUpManager.lettuce_enabled)
                {
                    DisplayNextSentence();
                }
            }
        }

        //"Fire1 to use the power"
        if (sentences.Count == 0)
        {
            if (Collectibles.collisionObj == "Pickle")
            {
                if (powerUpManager.pickle_enabled && Input.GetButton("Fire1"))   //Input.GetKey(KeyCode.Alpha1))
                {
                    DisplayNextSentence();
                }
            }
            else if (Collectibles.collisionObj == "Cheese")
            {
                if (powerUpManager.cheese_enabled && Input.GetButton("Fire1"))
                {
                    DisplayNextSentence();
                }
            }
            else if (Collectibles.collisionObj == "Tomato")
            {
                if (powerUpManager.tomato_enabled && Input.GetButton("Fire1"))
                {
                    DisplayNextSentence();
                }
            }
            else if (Collectibles.collisionObj == "Lettuce")
            {
                if (powerUpManager.lettuce_enabled && Input.GetButton("Fire1"))
                {
                    DisplayNextSentence();
                }
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (animator) {
            animator.SetBool("IsOpen", true);
        }
        sentences.Clear();
        timer = countdown;
        doCountdown = true;

        foreach (string sentence in dialogue.sentences)
        {
			if (Input.GetJoystickNames ().Length == 0) {
				if (sentence.Length == 1) {
					sentences.Enqueue ("Press '" + sentence + "' or scroll to toggle to your new power!");
				} else if (sentence.Length == 9 || sentence.Length == 6 || sentence.Length == 5) {
					sentences.Enqueue ("Press 'Z' to " + sentence + "!");
				} else {
					Debug.Log (sentence.Length);
					sentences.Enqueue (sentence);
				}
			} 
			else if (Input.GetJoystickNames().Length == 1) {
				if (sentence.Length == 1) {
					sentences.Enqueue ("Press LB/RB to toggle to your new power!");
				} else if (sentence.Length == 9 || sentence.Length == 6 || sentence.Length == 5) {
					sentences.Enqueue ("Press 'X' to " + sentence + "!");
				} else {
					Debug.Log (sentence.Length);
					sentences.Enqueue (sentence);
				}
			}
        }
        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    
        void EndDialogue()
    {
        if (animator) {
            animator.SetBool("IsOpen", false);
        }
    }
}
