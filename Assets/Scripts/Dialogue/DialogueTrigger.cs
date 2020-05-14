using UnityEngine;

// Comienza el diálogo cuando el jugador entra en el trigger del checkpoint 

public class DialogueTrigger : MonoBehaviour
{
    DialogueManager diaMan;
    int checkpointDeadVal;

    void Start()
    {
        diaMan = GetComponent<DialogueManager>();
        checkpointDeadVal = GetComponent<Checkpoint>().deadVal;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Comienza el diálogo si no ha pasado todavía por el checkpoint que lo contiene
        if (collision.GetComponent<PlayerController>() != null && GameManager.instance.deadVal != checkpointDeadVal)
        {
            Debug.Log("entró");
            diaMan.StartDialogue();
            this.enabled = false;
        }
    }
}
