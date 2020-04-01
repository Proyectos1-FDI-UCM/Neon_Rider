using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Este script solo tiene como propósito destruir las explosiones de los drones después de un tiempo
    float time = 1;

    void Update()
    {
        if (time >= 0)
            time -= Time.deltaTime;
        else
            Destroy(this.gameObject);
    }
}
