using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;

    public Animator boxAnim;
    public Animator startAnim;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);

        //nameText.text = dialogue.name;
        sentences.Clear();
        for(int i = 0; i < dialogue.sentences.Length; i++)
        {
            sentences.Enqueue(dialogue.name[i]);
            sentences.Enqueue(dialogue.sentences[i]);
        }
        //foreach(string sentence in dialogue.sentences)
        //{
        //    sentences.Enqueue(sentence);
        //}
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string name = sentences.Dequeue();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(name ,sentence));
    }

    IEnumerator TypeSentence(string name, string sentence)
    {
        nameText.text = name;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        boxAnim.SetBool("boxOpen", false);
    }
}
