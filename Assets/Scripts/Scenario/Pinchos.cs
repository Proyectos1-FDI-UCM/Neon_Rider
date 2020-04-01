using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] float intermitentTime = 1.5f;
    bool cont = true;
    double time;
    new Collider2D collider;
    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (cont)
        {
            time = intermitentTime + Time.time;
            cont = false;
        }
        if (Time.time>=time)
        {
            if  (collider.enabled)
            {
                collider.enabled = false;
            }
            else
            {
                collider.enabled = true;
            }
            cont = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy_Death dead = collision.gameObject.GetComponent<Enemy_Death>();
        if (dead != null)
        {
           dead.OnAttack();
        }
    }

}
