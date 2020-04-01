using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlasherRay : MonoBehaviour
{
    [SerializeField] float speed = 0f;          //Velocidad dedisparo
    [SerializeField] float duration = 0f;       //Tiempo que dura el rayo en pantalla
    private float timeDuration;     

    Transform player;

    Rigidbody2D rb;
    bool crash = false;
    Vector3 flasher;
    AudioSource laser;

    void Awake()
    {
        player = GetComponentInParent<EnemyVision>().player;    //Almacena el transform del player

        timeDuration = duration + Time.time;        //Inicializacion contador tiempo

        if (player != null)
        {
            flasher = transform.position;       

            rb = GetComponent<Rigidbody2D>();
            rb.velocity = (player.position - flasher).normalized * speed;       //Nomraliza el vector que une flasher-player y lo multiplpica por speed=Velociad del rayo
            transform.parent = null;
            Vector3 diference = player.position - transform.position;           //Calcula la distancia entre player y flasher
            float rotationz = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;    //Rota el rayo para que apunte al jugador
            transform.rotation = Quaternion.Euler(0f, 0f, rotationz);                   
        }
    }
    void FixedUpdate()
    {        
        Vector3 pos = rb.transform.position;        
        Vector3 increm = new Vector3((flasher.x- pos.x)*2, 0.5f, 1);        //Increm.x calcula la distancia entre flasher y player y la duplica(aumento a izq y dcha)
        transform.localScale = increm;       
    }
    void OnCollisionEnter2D(Collision2D collision)     
    {
        if (collision.gameObject.layer == 9)        //Si toca una pared
        {
            Destroy(this.gameObject);
        }
    }
}

