using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] Transform playerT = null;
    [SerializeField] GameObject explosion = null;
    [SerializeField] float speed = 10f;
    bool onRange = false;
    PlayerController obj;
    [SerializeField] float time = 0.6f;
    Vector2 direction;
    Rigidbody2D rb;
    EnemyVision vision;
    
    void Start()
    {
        vision = GetComponent<EnemyVision>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
   
        if (onRange) // La variable onRange controla si el dron tiene que preparase para explotar o no
        {
            direction = Vector2.zero;
            if (time > 0)
                time -= Time.deltaTime;
            if (time <= 0)
            {
                Debug.Log("Pum");
                Instantiate(explosion, transform.position, Quaternion.identity, null); // Al explotar hace aparecer un gameObject que representa la explosión
                Destroy(this.gameObject);
            }
        }
        else if (!onRange && vision.Spotted(playerT))
        {
            direction = new Vector2(playerT.position.x - transform.position.x, playerT.position.y - transform.position.y);
            direction.Normalize();
        }
    
   
    }

    private void FixedUpdate()
    {
            rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) // Al detectar colisión del jugador cambia onRange a true
    {
        obj = collision.gameObject.GetComponent<PlayerController>();

        if(obj != null)
        {
            onRange = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll; // Congela la posición para que no se pueda empujarlo antes de que explote
        }
    }

   
}
