using System.Diagnostics;
using UnityEngine;

// Asociado a la bala. Toma la posición del jugador y se mueve hacia ella con una velocidad constante

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    Transform player;
    
    Enemy_Death death;
    Rigidbody2D rb;
    void Start()
    {
        player = GetComponentInParent<EnemyAttack>().player;
        AudioManager.instance.Play(AudioManager.ESounds.MatonShot);
        if (player != null)
        {
            transform.parent = null;
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = (player.position - transform.position).normalized * speed;       
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        death = collision.gameObject.GetComponent<Enemy_Death>();
        
        if (death != null)
        {
            death.OnAttack();
        }
        Destroy(this.gameObject);
    }


}
