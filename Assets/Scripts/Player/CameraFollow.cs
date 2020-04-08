using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player = null;
    [SerializeField] float delay = 0.25f;

    private void Start()
    {
        player = GameManager.instance.GetPlayer().transform;
    }
    void FixedUpdate()
    {
        if (player != null)
        {
            // Coge la posición del jugador
            Vector3 playerPos = new Vector3(player.position.x, player.position.y, -10);

            // Si el jugador está activo (vivo), la cámara le sigue en un intervalo de tiempo dado por delay
            if (player.gameObject.activeSelf)
                transform.position = Vector3.Lerp(transform.position, playerPos, delay);
        }
    }
}
