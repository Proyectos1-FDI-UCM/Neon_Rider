using UnityEngine;

// Asociado a la bala. Toma la posición del jugador y se mueve hacia ella con una velocidad constante

public class TurretAttack : MonoBehaviour
{
    int numBullets = 5;
    [SerializeField] GameObject bulletPrefab = null;
    public void TurAttack(Transform player){
        Vector2 dir = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y), dirAux = dir;
        if (bulletPrefab != null)
            for(int i = 0; i < numBullets; i++){
                switch (i)
                {
                    case 0:
                        dir.x--;
                        break;
                    case 1:
                        //dir.x++;
                        break;
                    case 2:
                        dir.x++;
                        break;
                    case 3:
                        dir.y--;
                        break;
                    case 4:
                        dir.y++;
                        break;
                }
                Instantiate(bulletPrefab, transform);
                GetComponentInChildren<TurretBullet>().SetDir(dir);
                dir = dirAux;
            }
    }
}
