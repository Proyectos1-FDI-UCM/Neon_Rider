using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
    //meter al jugador para que muera
{
    [SerializeField] GameObject muerto = null;
    bool active = true;

    private void OnEnable()
    {
        active = true;
    }
    private void OnDisable()
    {
        active = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<TurretBullet>() != null ||
        if (( collision.gameObject.GetComponent<Bullet>() != null || collision.gameObject.GetComponent<PrestBullet>() != null || collision.gameObject.GetComponent<Explosion>() || collision.gameObject.GetComponent<Pinchos>() != null || collision.gameObject.GetComponent<Activada>() != null) && active)
        {
            Instantiate(muerto, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
