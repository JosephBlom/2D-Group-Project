using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI npcText;
    public TextMeshProUGUI npcName;
    public AudioSource audioSource;
    public AudioClip Clip;
    public GameObject continueButton;

    void Start()
    {
        npcName.text = "";
        npcText.text = "";
        continueButton.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        continueButton.SetActive(true);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        
        string sentence = sentences.Dequeue();
        if(sentences.Count == 0)
        {
            npcName.text = "Mom";
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            return;
        }
        if(sentences.Count % 2 != 0){
            npcName.text = "Dad";
        }
        else{
            npcName.text = "Mom";
        }

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
        if(sentences.Count == 0){
            EndDialogue();
        }
    }

    void EndDialogue(){
        continueButton.SetActive(false);
        audioSource.Stop();
        audioSource.clip = Clip;
        audioSource.loop = false;
        audioSource.Play();
    }
}
