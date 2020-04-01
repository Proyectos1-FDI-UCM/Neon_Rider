﻿using UnityEngine;

// Asociado a la bala. Toma la posición del jugador y se mueve hacia ella con una velocidad constante

public class TurretBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    Transform player;
    Bloqueo parry;

    Rigidbody2D rb;
    void Start()
    {

        player = GetComponentInParent<EnemyVision>().player;  

        if (player != null)
        {
            transform.parent = null;
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = (player.position - transform.position).normalized * speed;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            parry = collision.gameObject.GetComponent<Bloqueo>();
            if (collision.gameObject.GetComponent<EnemyVision>() == null)
            {
                Destroy(this.gameObject);
                if (parry != null && parry.enabled == true) // Para los casos de parry
                {
                    Debug.Log("Parryada");
                }
            }
        
    }
}
