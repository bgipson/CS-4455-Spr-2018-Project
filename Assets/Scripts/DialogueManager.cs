using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    //https://www.youtube.com/watch?v=_nRzoTzeyxU

    public Text dialogueText;
    public Animator animator;
    int countdown = 150;
    public int timer;
    public bool doCountdown;
    private Queue<string> sentences;
    public PowerUpManager powerUpManager;

    void Start () {
        sentences = new Queue<string>();
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
        animator.SetBool("IsOpen", true);
        sentences.Clear();
        timer = countdown;
        doCountdown = true;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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
        animator.SetBool("IsOpen", false);
    }
}
