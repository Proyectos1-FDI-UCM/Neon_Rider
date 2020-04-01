using UnityEngine;

// 
public class Enemy_Death : MonoBehaviour
{
    public int hitsToDeath; //golpes que aguanta el enemigo
    int hits = 0; //golpes que has dado al enemigo
    Transform child;
    EnemyVision enemy;
    Drone drone;

    private void Start()
    {
        enemy = GetComponent<EnemyVision>();
        drone = GetComponent<Drone>();

        // Si no es el ralentizador cogemos al hijo
        if (enemy != null || drone != null)
            child = transform.GetChild(0);
    }
    // Metodo llamado desde el componente Sword_Attack
    public void OnAttack()
    {
        hits++;

        if (enemy != null && hits == hitsToDeath)
        {
            // Separamos al hijo del padre
            // Llamamos a Animation de "EnemyDeathAnim"
            if (child.GetComponent<Animator>() != null)
            {
                child.GetComponent<Animator>().SetBool("Death", true);
                child.SetParent(null);
            }
            Destroy(this.gameObject);
        }
        else
        {
            if (hits == hitsToDeath)
            {
                // Destruimos el objeto
                Destroy(this.gameObject);
            }
        }
    }
}