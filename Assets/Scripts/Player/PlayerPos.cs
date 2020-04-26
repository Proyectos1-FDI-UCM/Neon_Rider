using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    void Start()
    {
        transform.position = GameManager.instance.checkpoint;
    }
}