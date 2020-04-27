using UnityEngine;

// Asociado al enemigo. Instancia un objeto "bullet" con un tiempo entre invocaciones dado por la variable "cadencia"

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet = null;
    [SerializeField] float cadencia = 2, firstFire = 1f;
    EnemyVision vision;

    public Transform player;
    AnimatorStateInfo animState;
    EnemyVision enemy;
    Drone drone;
    Transform child;
    SpriteRenderer arm;
    Animator anim;
    Transform rotator;
    float fire = 0;
    AnimatorStateInfo estadoAnimacion;
    Animator animator, animatorArm;
    EnemyMovement movement;
    FlasherMovement flasher;
    bool hola = true;
    bool shooting;


    private void Start()
    {
        flasher = GetComponent<FlasherMovement>();
        movement = GetComponent<EnemyMovement>();
        enemy = GetComponent<EnemyVision>();
        drone = GetComponent<Drone>();
        
        if (enemy != null && drone == null)
        {
            child = transform.GetChild(0);
            animator = child.GetComponent<Animator>();
            animatorArm = child.GetChild(0).GetComponentInChildren<Animator>();
            anim = child.GetComponent<Animator>();
            rotator = child.GetChild(0);
            arm = child.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        }            
        vision = GetComponent<EnemyVision>();
    }

    void Update()
    {
        animState = anim.GetCurrentAnimatorStateInfo(0);
        if (flasher!=null)
            shooting = animState.IsName("FlasherBodyShot");
        else if (movement!=null)
            shooting = animState.IsName("Maton_Shooting");
        // Cuando "Time.time" alcanza el nuevo valor de "firstFire", Instancia un objeto 
        // "bullet" en la posición del enemigo y aumenta el valor de "firstFire" mediante
        // la variable "cadencia"

        if (transform != null)
        {
            // Diferencia entre los 2 vectores - player y DoubleBullet
            Vector3 difference = player.position - transform.position;
            // Devuelve el ángulo cuya tangente es y/x y lo aplica a la rotación del objeto
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;            
            if (player.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(-1f, 1f);
                rotator.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            }               
            else
            {
                transform.localScale = new Vector2(1f, 1f);
                rotator.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 180);
            }
                         
            if (hola && vision.Spotted(player))
            {
                fire = firstFire;
                firstFire = cadencia + Time.time;
                hola = false;
            }
            else if (Time.time > firstFire && !hola)
            {
                Instantiate(bullet, child.GetChild(0).GetChild(0).GetChild(0).position, Quaternion.identity, transform);
                hola = true;
                Debug.Log("ddoisg");
            }
            else if (Time.time>firstFire- 1 && vision.Spotted(player) && !shooting)
            {
                animator.SetBool("Shooting", true);
                animatorArm.SetBool("Shooting", true);
            }
            else if (shooting)
            {
                animator.SetBool("Shooting", false);
                animatorArm.SetBool("Shooting", false);
            }
            //else if (fire != 0 && Time.time>fire+ 0.2 && vision.Spotted(player) && movement!=null)
            //{
            //    animator.SetBool("Shooting", false);
            //    animatorArm.SetBool("Shooting", false);
            //}
            else if (!vision.Spotted(player))
            {
                animator.SetBool("Shooting", false);
                animatorArm.SetBool("Shooting", false);
                firstFire = 1;
                hola = true;
            }
            //estadoAnimacion = animator.GetCurrentAnimatorStateInfo(0);

            //bool atacando;
            //if (movement != null)
            //{
            //    atacando = estadoAnimacion.IsName("Maton_Shooting");
            //}
            //else 
            //{
            //    atacando = estadoAnimacion.IsName("FlasherBodyShoot");
            //}
            if (shooting) arm.enabled = true;
             
        }            
    }
}
