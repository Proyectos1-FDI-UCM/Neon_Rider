using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Se encarga de mostrar el cuadro de diálogo y sus mensajes, así como el control para pasar entre ellos

public class DialogueManager : MonoBehaviour
{ 
    Queue<string> sentences;
    bool currentlyInDialogue;

    public GameObject dialogueBox;
    public Text nameText;
    public Text dialogueText;

    void Start()
    {
        currentlyInDialogue = false;
        sentences = new Queue<string>();
    }
    void Update()
    {
        // Pasa al siguiente diálogo al presionar A, B o Espacio
        if (currentlyInDialogue && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space)))
        {
            DisplayNextSentence();
        }
    }
    // Mete en una Queue todos los mensajes que se van a mostrar
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        //anim.SetBool("Opened", true);
        nameText.text = dialogue.name;
        // Vacía la Queue
        sentences.Clear();
        
        // Mete en la Queue cada texto
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        currentlyInDialogue = true;
        DisplayNextSentence();
    }

    // Muestra cada mensaje del cuadro, uno a uno
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            // Da a DialogueText el siguiente string de la Queue
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
        }
    }
    void EndDialogue()
    {
        // Desactiva el cuadro de diálogo
        currentlyInDialogue = false;
        dialogueBox.SetActive(false);
    }
}
