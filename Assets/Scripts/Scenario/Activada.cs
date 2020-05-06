using UnityEngine;
using UnityEngine.SceneManagement;

public class Activada : MonoBehaviour
{
    [SerializeField] float activateTime = 10f;
    [SerializeField] float deactivateTime = 10f;
    int cont = 0;
    double time;
    new Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (cont == 1)
        {
            time = activateTime + Time.time;
            cont = 0;
        }
        if (Time.time >= time)
        {
            if (!collider.enabled)
            {
                collider.enabled = true;
                time = Time.time + deactivateTime;
            }
            
            else if (collider.enabled)
            {
                collider.isTrigger = true;
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Death>()!=null)
        {
            collider.enabled = false;
            collider.isTrigger = false;
            cont = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy_Death dead = collision.gameObject.GetComponent<Enemy_Death>();
        if (dead != null)
        {
            dead.OnAttack();
        }
        Death death = collision.gameObject.GetComponent<Death>();
        if (death != null)
            death.Dead();
    }
}
