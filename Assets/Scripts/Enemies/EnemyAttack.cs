using UnityEngine;

// Asociado al enemigo. Instancia un objeto "bullet" con un tiempo entre invocaciones dado por la variable "cadencia"

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet = null;
    [SerializeField] float cadencia = 2, firstFire = 0.5f;
    EnemyVision vision;
    Transform player;
    EnemyVision enemy;
    Drone drone;
    Transform child;
    SpriteRenderer arm;
    Transform rotator;
    float fire = 0;
    AnimatorStateInfo estadoAnimacion;
    Animator animator;


    private void Start()
    {
        enemy = GetComponent<EnemyVision>();
        drone = GetComponent<Drone>();
        if (enemy != null && drone == null)
        {
            child = transform.GetChild(0);
            animator = child.GetComponent<Animator>();
            rotator = child.GetChild(0);
            arm = child.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        }            
        vision = GetComponent<EnemyVision>();
        player = GameManager.instance.GetPlayer().transform;
    }

    void Update()
    {
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
                transform.localScale = new Vector2(-1.6f, 1.6f);
                rotator.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            }               
            else
            {
                transform.localScale = new Vector2(1.6f, 1.6f);
                rotator.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 180);
            }
                         
            if (Time.time > firstFire && vision.Spotted(player))
            {
                Instantiate(bullet, transform.position, Quaternion.identity, transform);
                fire = firstFire;
                firstFire = cadencia + Time.time;
            }
            else if (Time.time>firstFire- 1 && vision.Spotted(player))
            {
                child.GetComponent<Animator>().SetBool("Shooting", true);
            }
            else if (fire != 0 && Time.time>fire+ 0.2 && vision.Spotted(player))
            {
                child.GetComponent<Animator>().SetBool("Shooting", false);
            }
            estadoAnimacion = animator.GetCurrentAnimatorStateInfo(0);
            bool atacando = estadoAnimacion.IsName("Maton_Shooting");
            if (atacando) arm.enabled = true;
            else arm.enabled = false;
        }            
    }
}
