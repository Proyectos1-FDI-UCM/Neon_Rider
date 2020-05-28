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
    bool shooting = false;
    float clock = 0;
    bool first = true;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        child = transform.GetChild(0);
        animator = child.GetComponent<Animator>();
    }
    void Update()
    {
        clock += Time.deltaTime;
        animState = animator.GetCurrentAnimatorStateInfo(0);
        if (cont == 1)
        {
            time = activateTime;
            clock = 0;
            cont = 0;
            first = false;
        }
        if (clock >= time && !first)
        {
            if (!shooting)
            {
                //collider.enabled = true;
                shooting = true;
                time = deactivateTime;
                clock = 0;
                animator.SetBool("act", false);
            }
            
            else if (shooting)
            {
                //collider.isTrigger = true;
                shooting = false;
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Death>()!=null)
        {
            //collider.enabled = false;
            //collider.isTrigger = false;
            cont = 1;
            animator.SetBool("act", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (shooting)
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
}
