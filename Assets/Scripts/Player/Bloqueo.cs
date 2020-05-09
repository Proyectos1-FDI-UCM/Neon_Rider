using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]

/*
*   Componente del jugador
*   Activa el CircleCollider del jugador al recibir la orden desde el PlayerController
*/
public class Bloqueo : MonoBehaviour
{


    CircleCollider2D collisionArea;
    [SerializeField] float blockTime = 0.1f;
    float blocking;
    ActivatePowerUpRed activPow;
    ActivatePowerUpPurple activPowPurple;
    PowerUpPurple purple;


    private void Awake()
    {
        collisionArea = this.GetComponent<CircleCollider2D>();
        activPow = GetComponent<ActivatePowerUpRed>();
        activPowPurple = GetComponent<ActivatePowerUpPurple>();
        purple = GetComponent<PowerUpPurple>();
    }

    private void Update()
    {
        if (blocking <= Time.time)
            enabled = false;
    }

    private void OnEnable()
    {
        collisionArea.enabled = true;
        blocking = Time.time + blockTime;

    }

    private void OnDisable()
    {
        collisionArea.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled)
        {
            if (collision.GetComponent<Bullet>() != null)
            {
                if (!purple.enabled)
                {
                    Destroy(collision.gameObject);
                }
                activPow.AddToCont();
                Debug.Log("Parryada");
            }
            if (collision.GetComponent<PrestBullet>() != null && purple.enabled == false)
            {
                AudioManager.instance.Play(AudioManager.ESounds.Bloqueo3);
                Destroy(collision.gameObject);
                Debug.Log("BALA DESTRUIDA");

            }
            if (collision.GetComponent<TurretBullet>() != null && purple.enabled == false)
            {
                AudioManager.instance.Play(AudioManager.ESounds.Bloqueo3);
                Destroy(collision.gameObject);
                Debug.Log("BALA DESTRUIDA");

            }
        }
    }
}

