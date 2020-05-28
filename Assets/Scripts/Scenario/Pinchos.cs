using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] float intermitentTime = 1.5f;
    bool cont = true;
    double time;
    new Collider2D collider;
    Animator animator;
    Transform child;

    void Awake()
    {
        child = transform.GetChild(0);
        animator = child.GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (cont)
        {
            time = intermitentTime + Time.time;
            cont = false;
        }
        if (Time.time>=time) // TIME.TIME --------------------------------> TIME.DELTATIME
        {
            if  (collider.enabled)
            {
                collider.enabled = false;
                animator.SetBool("Active", false);
            }
            else
            {
                collider.enabled = true;
                animator.SetBool("Active", true);
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

        Death death = collision.gameObject.GetComponent<Death>();
        if (death != null)
            death.Dead();
    }

}
