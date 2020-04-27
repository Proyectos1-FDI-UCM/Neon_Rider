using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
// Asociado a la bala. Toma la posición del jugador y se mueve hacia ella con una velocidad constante

public class TurretBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    Rigidbody2D rb;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(this.gameObject);
        }
    
    }

    public void SetDir(Transform player)
    {
        if (player != null)
        {
            transform.parent = null;
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = (player.position - transform.position).normalized * speed;
        }
    }
}
