using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    public GameObject explosion;
    float speed = 5;
    bool onRange = false;
    PlayerController obj;
    float time = 3;
    Vector2 direction;
    Rigidbody2D rb;
    EnemyVision vision;
    
    void Start()
    {
        if (GameManager.instance.GetPlayer() != null)
            player = GameManager.instance.GetPlayer().transform;
        else
            player = null;
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
        else if (!onRange && vision.Spotted(player))
        {
            direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
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
