using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBlue : MonoBehaviour
{
    private PlayerController movi;
    private float fixedDeltaTime;
    private void Awake()
    {
        //Guardamos el DeltaTime inicial
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void OnEnable()
    {
        //Al activarse duplicamos la velocidad del player y reducimos el timeScale a la mitad
        movi = gameObject.GetComponent<PlayerController>();
        movi.speed *= 3;
        gameObject.GetComponent<Animator>().speed=3;
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
    private void OnDisable()
    {
        //Al desactivarse devolvemos todos los valores a su estado inicial.
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        gameObject.GetComponent<Animator>().speed = 1;
        movi = gameObject.GetComponent<PlayerController>();
        movi.speed /= 3;
    }
}
