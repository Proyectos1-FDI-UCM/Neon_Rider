using UnityEngine;

// Asociado al objeto vacío DoubleBullet. Hace rotar el objeto y activa los objetos hijos bullet con un intervalo de tiempo entre medias

public class PrestDouble : MonoBehaviour
{
    public Transform player;
    PrestEnemyMovement enemyMov;
    GameObject firstBullet, secondBullet;
    [SerializeField] float secondFire = 10f, firstFire = 7f;

    void Start()
    {
        enemyMov = GetComponentInParent<PrestEnemyMovement>();
        enemyMov.enabled = false;
        player = GetComponentInParent<EnemyVision>().player;

        // Cogemos las balas por separado
        firstBullet = transform.GetChild(0).gameObject;
        secondBullet = transform.GetChild(1).gameObject;

        // Gestionamos tiempos de disparo
        firstFire += Time.time;
        secondFire += firstFire;
    }

    void Update()
    {
        if (player != null)
        {
            // Diferencia entre los 2 vectores - player y DoubleBullet
            Vector3 difference = player.position - transform.position;
            // Devuelve el ángulo cuya tangente es y/x y lo aplica a la rotación del objeto
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);
        }

        // Activa el comportamiento de las balas tras un tiempo
        if (Time.time > firstFire && firstBullet != null)
        {
            firstFire = 100;
            firstBullet.GetComponent<PrestBullet>().enabled = true;  
        }

        if (Time.time > secondFire && secondBullet != null)
        {
            secondFire = 100;
            secondBullet.GetComponent<PrestBullet>().enabled = true;
            enemyMov.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
