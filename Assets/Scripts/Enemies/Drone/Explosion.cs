﻿using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Este script solo tiene como propósito destruir las explosiones de los drones después de un tiempo
    float time = 1.05f;
    CircleCollider2D circle;
    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            if(circle.radius < 2)
            {
                circle.radius += Time.deltaTime;
            }
        }
        else
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) //En caso de tocar al jugador, éste muere
    {
        Death dead = collision.gameObject.GetComponent<Death>();
        if (dead != null)
            dead.Dead();
    }
}
