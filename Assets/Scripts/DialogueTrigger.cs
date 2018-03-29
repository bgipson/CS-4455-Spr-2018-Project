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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Burgie")
        {
            //Debug.LogError("collision w/ burgie");
            TriggerDialogue();
        }
        //else Debug.LogError("collision w/o burgie");
    }
}
