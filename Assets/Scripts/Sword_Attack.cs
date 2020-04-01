using UnityEngine;

public class Sword_Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("he entrado");
        //Cacheamos que el GameObject que entre tenga el componente asociado
        //Guardamos el componente en enemy
        Enemy_Death enemy;
        enemy = other.gameObject.GetComponent<Enemy_Death>();
        DestructibleWall wall;
        wall = other.gameObject.GetComponent<DestructibleWall>();
        //Debug.Log("ay me matieaste");

        //Si el GameObject tiene el componente, llama al metodo de dicho componente
        if (enemy != null && enabled && enemy.enabled)
        {
            enemy.OnAttack();
            Debug.Log("verga");
        }

        //Si tiene el componente DestructibleWall, llama a su método
        else if(wall != null && enabled)
        {
            wall.Break();
        }
    }
}
