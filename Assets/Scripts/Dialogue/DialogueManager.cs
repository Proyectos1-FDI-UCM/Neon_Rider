using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Se encarga de mostrar el cuadro de diálogo y sus mensajes, así como el control para pasar entre ellos

public class DialogueManager : MonoBehaviour
{
    // Dialogue
    [SerializeField]
    string name;
    [SerializeField]
    string secondName;
    [SerializeField]
    int[] nameChanger;
    int changerCont;

    [SerializeField]
    [TextArea(3, 10)]
    string[] sentences;

    // Manager
    Queue<string> queuedSentences;
    bool currentlyInDialogue;

    public GameObject dialogueBox;
    public Text nameText;
    public Text dialogueText;
    int cont = 0;

    void Start()
    {
        currentlyInDialogue = false;
        queuedSentences = new Queue<string>();
        changerCont = 0;
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
    public void StartDialogue()
    {
        dialogueBox.SetActive(true);
        nameText.text = name;
        // Vacía la Queue
        queuedSentences.Clear();

        // Mete en la Queue cada texto
        foreach (string sentence in sentences)
        {
            queuedSentences.Enqueue(sentence);
        }

        currentlyInDialogue = true;
        DisplayNextSentence();
    }

    // Muestra cada mensaje del cuadro, uno a uno
    public void DisplayNextSentence()
    {
        // Cambia el nombre del emisor en los mensajes marcados por nameChanger
        if (changerCont < nameChanger.Length)
        {
            if (cont == nameChanger[changerCont] && nameText.text == name)
            {
                nameText.text = secondName;
                changerCont++;
            }
            else if (cont == nameChanger[changerCont] && nameText.text == secondName)
            {
                nameText.text = name;
                changerCont++;
            }
        }

        // Termina el diálogo o lo continua
        if (queuedSentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            // Da a DialogueText el siguiente string de la Queue
            string sentence = queuedSentences.Dequeue();
            dialogueText.text = sentence;
        }
        cont++;
    }
    void EndDialogue()
    {
        // Desactiva el cuadro de diálogo
        currentlyInDialogue = false;
        dialogueBox.SetActive(false);
    }
}
