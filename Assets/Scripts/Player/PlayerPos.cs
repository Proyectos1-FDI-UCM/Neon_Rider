using UnityEngine;

// SCRIPT SIN REFERENCIAS

public class PlayerPos : MonoBehaviour
{
    void Start()
    {
        transform.position = GameManager.instance.checkpoint;
    }
}