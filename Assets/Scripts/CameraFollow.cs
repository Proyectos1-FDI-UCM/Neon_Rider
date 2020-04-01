using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform tr = null;
    [SerializeField] float delay = 0.25f;

    void FixedUpdate()
    {
        if (tr != null)
        {
            // Coge la posición del jugador
            Vector3 playerPos = new Vector3(tr.position.x, tr.position.y, -10);

            // Si el jugador está activo (vivo), la cámara le sigue en un intervalo de tiempo dado por delay
            if (tr.gameObject.activeSelf)
                transform.position = Vector3.Lerp(transform.position, playerPos, delay);
        }
    }
}
