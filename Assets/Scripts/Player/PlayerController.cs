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
        Vector2 direccionx;
        Vector2 direcciony;
        if (GameManager.instance.mando) // MANDO
        {
            direccion = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            direccion.Normalize();
        }
        else // TECLADO Y RATÓN
        {
            if (Input.GetKey("w")) direcciony = new Vector2(0, 1);
            else if (Input.GetKey("s")) direcciony = new Vector2(0, -1);
            else direcciony = new Vector2(0, 0);

            if (Input.GetKey("d")) direccionx = new Vector2(1, 0);
            else if (Input.GetKey("a")) direccionx = new Vector2(-1, 0);
            else direccionx = new Vector2(0, 0);

            direccion = direccionx + direcciony;
        }
        anim[0].SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
        anim[1].SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
    }

    private void FixedUpdate()
    {
        rb.velocity = direccion * speed;
    }
}
