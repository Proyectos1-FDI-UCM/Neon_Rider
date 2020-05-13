using UnityEngine;
using UnityEngine.SceneManagement;

public class Activada : MonoBehaviour
{
    [SerializeField] float activateTime = 10f;
    [SerializeField] float deactivateTime = 10f;
    int cont = 0;
    double time;
    Animator animator;
    Transform child;
    new Collider2D collider;
    AnimatorStateInfo animState;
    bool shooting;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        child = transform.GetChild(0);
        animator = child.GetComponent<Animator>();
    }
    void Update()
    {
        animState = animator.GetCurrentAnimatorStateInfo(0);
        shooting = animState.IsName("TrampaAct");
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
                animator.SetBool("act", false);
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
            animator.SetBool("act", true);
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
