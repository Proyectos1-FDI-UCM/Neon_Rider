using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] float intermitentTime = 1.5f;
    bool cont = true;
    double time = 0;
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
        time += Time.deltaTime;
        if (cont)
        {
            time = 0;
            cont = false;
        }
        if (time>= intermitentTime) // TIME.TIME --------------------------------> TIME.DELTATIME
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
