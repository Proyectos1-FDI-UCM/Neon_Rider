using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossCrystal : MonoBehaviour
{
    [SerializeField] BossBehaviour boss = null;

    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        CircleCollider2D sword = collision.gameObject.GetComponent<CircleCollider2D>();

        if(player != null && sword != null)
        {
            if (boss != null)
                boss.UpdateEnemies();

            Debug.LogWarning("Crystal Destroy");

            Destroy(this.gameObject);
        }
    }


}
