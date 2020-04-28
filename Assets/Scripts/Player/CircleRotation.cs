﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gira el círculo indicador de la dirección de apuntado del personaje para atacar o bloquear

public class CircleRotation : MonoBehaviour
{
    void Update()
    {
        if (!GameManager.instance.gameIsPaused)
        {
            if (GameManager.instance.mando)
            {
                // Si se usa el joystick derecho para apuntar
                if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    // Devuelve el ángulo cuya tangente es y/x y lo aplica a la rotación del objeto
                    float rotationX = Mathf.Atan2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(rotationX, 90f, 90f);
                }
                else
                {
                    // Devuelve el ángulo cuya tangente es y/x y lo aplica a la rotación del objeto
                    float rotationX = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(rotationX, 90f, 90f);
                }
            }
            else
            {
                Vector2 direccion, direccionx, direcciony;
                if (Input.GetKey("w")) direcciony = new Vector2(0, 1);
                else if (Input.GetKey("s")) direcciony = new Vector2(0, -1);
                else direcciony = new Vector2(0, 0);

                if (Input.GetKey("d")) direccionx = new Vector2(1, 0);
                else if (Input.GetKey("a")) direccionx = new Vector2(-1, 0);
                else direccionx = new Vector2(0, 0);

                direccion = direccionx + direcciony;
                float rotationX = Mathf.Atan2(direccion.x,direccion.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(rotationX, 90f, 90f);
            }
        }
    }
}
