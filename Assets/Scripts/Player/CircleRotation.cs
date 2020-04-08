using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gira el círculo indicador de la dirección de apuntado del personaje para atacar o bloquear

public class CircleRotation : MonoBehaviour
{
    void Update()
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
}
