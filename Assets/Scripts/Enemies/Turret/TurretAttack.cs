using UnityEngine;

// Asociado a la bala. Toma la posición del jugador y se mueve hacia ella con una velocidad constante

public class TurretAttack : MonoBehaviour
{
    [SerializeField] int numBullets = 3;
    [SerializeField] GameObject bulletPrefab = null;
    public void TurAttack(Transform player){

        Vector2 dir = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);

        if(bulletPrefab != null)
            for(int i = 0; i < numBullets; i++){
                Instantiate(bulletPrefab, transform);
                GetComponentInChildren<TurretBullet>().SetDir(player);
            }
    }
}
