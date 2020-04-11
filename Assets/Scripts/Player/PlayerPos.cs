using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    PlayerController controller = null;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        controller.enabled = true;
    }

    void Start()
    {
        transform.position = GameManager.instance.checkpoint;
    }
}