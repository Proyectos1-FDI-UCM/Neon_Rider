using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    public int hitsToDeath; //golpes que aguanta el enemigo
    [SerializeField] int deadVal = 0;
    Transform child;
    EnemyVision enemy;
    Drone drone;
    Turret turret;
    PrestEnemyAttack prest;


    private void Start()
    {
        // Si se reanuda desde un checkpoint posicionado después del enemigo,
        // éste es destruido
        if (GameManager.instance.deadVal >= deadVal)
        {
            Destroy(this.gameObject);
        }

        prest = GetComponent<PrestEnemyAttack>();
        enemy = GetComponent<EnemyVision>();
        drone = GetComponent<Drone>();
        turret = GetComponent<Turret>();
        // Si no es el ralentizador cogemos al hijo
        if (prest != null && enemy != null && drone == null && turret == null)
            child = transform.GetChild(0);
    }
    // Metodo llamado desde el componente Sword_Attack
    public void OnAttack()
    {
        hitsToDeath--;

        if (enemy != null && hitsToDeath == 0)
        {
            // Separamos al hijo del padre
            // Llamamos a Animation de "EnemyDeathAnim"
            if (child.GetComponent<Animator>() != null)
            {
                child.GetComponent<Animator>().SetBool("Death", true);
                if (prest == null)
                    child.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = false;
                child.SetParent(null);
            }
            Destroy(this.gameObject);
        }
        else
        {
            if (hitsToDeath == 0)
            {
                // Destruimos el objeto
                Destroy(this.gameObject);
            }
        }
    }
}