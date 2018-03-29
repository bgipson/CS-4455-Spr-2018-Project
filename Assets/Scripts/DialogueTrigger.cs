using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    //https://www.youtube.com/watch?v=_nRzoTzeyxU

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Burgie")
        {
            TriggerDialogue();
        }
    }
}
