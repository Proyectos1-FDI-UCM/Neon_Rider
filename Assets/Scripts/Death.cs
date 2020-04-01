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
        if ((collision.gameObject.GetComponent<Bullet>() != null || collision.gameObject.GetComponent<PrestBullet>() != null || collision.gameObject.GetComponent<Explosion>()) && active)
        {
            Instantiate(muerto, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
