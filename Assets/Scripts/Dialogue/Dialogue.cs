using UnityEngine;

// Contiene los datos que utilizarán los scripts DialogueManager y DialogueTrigger

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}