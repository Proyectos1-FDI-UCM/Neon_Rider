using UnityEngine;

// Asociado a la bala. Toma la posición del jugador y se mueve hacia ella con una velocidad constante

public class PrestBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    
    Transform player;
    Bloqueo parry;
    Enemy_Death death;
    Rigidbody2D rb;

    void OnEnable()
    {
        player = GetComponentInParent<PrestDouble>().player;

        if (player != null)
        {
            transform.parent = null;
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = (player.position - transform.position).normalized * speed;
            
        }
    }

    // Permite los bloqueos y destrucción de la bala
    private void OnCollisionEnter2D(Collision2D collision)
    {
        death = collision.gameObject.GetComponent<Enemy_Death>();
        parry = collision.gameObject.GetComponent<Bloqueo>();
        if (parry==null)
        {
            Debug.Log("TOCO PARED o MATO");
        if (death != null )
        {
            death.OnAttack();
        }
            Destroy(this.gameObject);
            if (parry != null && parry.enabled == true) // Para los casos de parry
            {
                Debug.Log("Parryada");
            }
        }     
    }
}
