using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public int waitSeconds = 5;
    public GameObject dialogueTrigger;
    void Start()
    { 
        StartCoroutine(startDialogue());
    }
    private IEnumerator startDialogue(){
        yield return new WaitForSeconds(waitSeconds);
        dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
