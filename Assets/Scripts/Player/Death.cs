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
    public void Dead()
    {
        if (active)
        {
            Instantiate(muerto, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
