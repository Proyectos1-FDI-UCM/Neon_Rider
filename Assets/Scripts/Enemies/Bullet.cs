using System.Diagnostics;
using UnityEngine;

// Asociado a la bala. Toma la posición del jugador y se mueve hacia ella con una velocidad constante

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    Transform playerT;
    Bloqueo parry;
    Enemy_Death death;
    Rigidbody2D rb;
    void Start()
    {
        playerT = GetComponentInParent<Transform>();
        if (playerT != null)
        {
            transform.parent = null;
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = (playerT.position - transform.position).normalized * speed;       
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        death = collision.gameObject.GetComponent<Enemy_Death>();
        parry = collision.gameObject.GetComponent<Bloqueo>();
        if (death != null)
        {
            death.OnAttack();
        }
        Destroy(this.gameObject);
    }


}
