using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI npcText;
    public TextMeshProUGUI npcName;


    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if(sentences.Count % 2 != 0){
            npcName.text = "Mom";
        }
        else{
            npcName.text = "Dad";
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        npcText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            npcText.text += letter;
            yield return null;
        }
    }

    void EndDialogue(){
        Debug.Log("End of the conversation");
    }
}
