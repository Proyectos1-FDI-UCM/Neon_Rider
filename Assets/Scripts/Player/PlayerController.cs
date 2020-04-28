using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    Vector2 direccion;
    Animator[] anim;
    Rigidbody2D rb;
    /*
    int attackIndicator;
    AnimatorStateInfo animState;
    CircleCollider2D attackCollider;
    Sprite playerSpr;
    bool attackBool, blockBool;
    Bloqueo parry;
    AudioSource swing;
    */
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim[0] player //anim[1] sword
        anim = GetComponentsInChildren<Animator>();

        Cursor.visible = false;
    }

    void Update()
    {
        direccion = Input.GetAxis("Horizontal") * Vector2.right + Input.GetAxis("Vertical") * Vector2.up;
        direccion.Normalize();
        anim[0].SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
        anim[1].SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
    }

    private void FixedUpdate()
    {
        rb.velocity = direccion * speed;
    }


}
