using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    Vector2 direccion;
    Animator anim;
    Rigidbody2D rb;

    int attackIndicator;
    AnimatorStateInfo animState;
    CircleCollider2D attackCollider;
    Sprite playerSpr;
    bool attackBool, blockBool;
    Bloqueo parry;
    AudioSource swing;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Cursor.visible = false;
        anim = GetComponent<Animator>();
        attackCollider = GetComponent<CircleCollider2D>();
        parry = GetComponent<Bloqueo>();
        swing = GetComponent<AudioSource>();
    }

    void Update()
    {
        direccion = Input.GetAxis("Horizontal") * Vector2.right + Input.GetAxis("Vertical") * Vector2.up;
        direccion.Normalize();
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
    }

    private void FixedUpdate()
    {
        rb.velocity = direccion * speed;
    }


}
