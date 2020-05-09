using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Este script solo tiene como propósito destruir las explosiones de los drones después de un tiempo
    float time = 0.5f;

    void Update()
    {
        if (time >= 0)
            time -= Time.deltaTime;
        else
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) //En caso de tocar al jugador, éste muere
    {
        Death dead = collision.gameObject.GetComponent<Death>();
        if (dead != null)
            dead.Dead();
    }
}
