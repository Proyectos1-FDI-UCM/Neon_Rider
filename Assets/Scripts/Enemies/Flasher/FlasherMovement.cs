using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlasherMovement : MonoBehaviour
{
    [SerializeField] Transform player = null;
    void Update()
    {
        if (player!=null)       //Si tiene un player asociado
        {
            Vector3 diference = player.position - transform.position;       //Vector que guarda la dirreccion de la linea que une flasher-player
            float rotationz = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;        //Calculamos el angulo
            transform.rotation = Quaternion.Euler(0f, 0f, rotationz+180);                   //Rota el flasher hacia el jugador
        }
    }
}
