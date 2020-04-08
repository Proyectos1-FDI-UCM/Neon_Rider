using UnityEngine;
using UnityEngine.Audio;

public class AimController : MonoBehaviour
{
    Animator anim;
    int attackIndicator;
    AnimatorStateInfo animState;
    CircleCollider2D attackCollider;
    Sprite playerSpr;
    bool attackBool, blockBool;
    Bloqueo parry;

    private void Awake()
    {
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        attackCollider = GetComponent<CircleCollider2D>();
        parry = GetComponent<Bloqueo>();
    }

    void Update()
    {
        //Cogemos el estado de la animacion en cada frame
        animState = anim.GetCurrentAnimatorStateInfo(0);
        //Hacemos que el booleano se active solo cuando se activa la animación
        attackBool = animState.IsName("Player_Attack");
        blockBool = animState.IsName("Player_Block");
        playerSpr = GetComponent<SpriteRenderer>().sprite;
        if (playerSpr.name == "Attack_Right" || playerSpr.name == "Attack_Left" || playerSpr.name == "Attack_Down" || playerSpr.name == "Attack_Up" || blockBool)
        {
            attackCollider.enabled = true;
        }
        else
        {
            attackCollider.enabled = false;
        }

        Vector2 mov;

        // Mientras no estén activas las animaciones de ataque o bloqueo, el 
        // jugador apunta en la dirección en la que se mueve
        if (!attackBool && !blockBool)
        {
            mov = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            // Si se mueve el joystick en el eje horizontal:
            if (Mathf.Abs(mov.x) >= Mathf.Abs(mov.y) && mov != Vector2.zero && !GameManager.instance.gameIsPaused)
            {
                anim.SetFloat("PosY", 0);
                if (mov.x >= 0) // Mirar Derecha
                {
                    anim.SetFloat("PosX", 1);
                    attackIndicator = 1;
                }
                else // Mirar Izquierda
                {
                    anim.SetFloat("PosX", -1);
                    attackIndicator = 2;
                }
            }

            else if (mov != Vector2.zero && !GameManager.instance.gameIsPaused)
            {
                anim.SetFloat("PosX", 0);
                if (mov.y >= 0) // Mirar Arriba
                {
                    anim.SetFloat("PosY", 1);
                    attackIndicator = 3;

                }
                else // Mirar Abajo
                {
                    anim.SetFloat("PosY", -1);
                    attackIndicator = 4;
                    //Debug.Log(indicadorAtaque);

                }
            }
        }

        if (Input.GetKeyDown("joystick button 5") && !attackBool && !blockBool && !GameManager.instance.gameIsPaused)
        {
            GetComponent<Sword_Attack>().enabled = true;
            Attack(attackIndicator, ref anim, ref attackCollider);
        }

        else if (Input.GetKeyDown("joystick button 4") && !attackBool && !blockBool && !GameManager.instance.gameIsPaused)
        {

            mov = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            // Si se mueve el joystick en el eje horizontal:
            if (Mathf.Abs(mov.x) >= Mathf.Abs(mov.y) && mov != Vector2.zero && !GameManager.instance.gameIsPaused)
            {
                anim.SetFloat("PosY", 0);
                if (mov.x >= 0) // Mirar Derecha
                {
                    anim.SetFloat("PosX", 1);
                    attackIndicator = 1;
                }
                else // Mirar Izquierda
                {
                    anim.SetFloat("PosX", -1);
                    attackIndicator = 2;
                }
            }

            else if (mov != Vector2.zero && !GameManager.instance.gameIsPaused)
            {
                anim.SetFloat("PosX", 0);
                if (mov.y >= 0) // Mirar Arriba
                {
                    anim.SetFloat("PosY", 1);
                    attackIndicator = 3;

                }
                else // Mirar Abajo
                {
                    anim.SetFloat("PosY", -1);
                    attackIndicator = 4;
                    //Debug.Log(indicadorAtaque);

                }
            }

            GetComponent<Sword_Attack>().enabled = false;
            anim.SetTrigger("Block");
            switch (attackIndicator)
            {
                case 1:
                    attackCollider.offset = new Vector2(0.3f, 0);
                    break;
                case 2:
                    attackCollider.offset = new Vector2(-0.3f, 0);
                    break;
                case 3:
                    attackCollider.offset = new Vector2(0, 0.2f);
                    break;
                case 4:
                    attackCollider.offset = new Vector2(0, -0.2f);
                    break;
            }
            parry.enabled = true;
        }
    }

    static void Attack(int attackIndicator, ref Animator anim, ref CircleCollider2D attackCollider)
    {
        Vector2 mov = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        // Si se mueve el joystick en el eje horizontal:
        if (Mathf.Abs(mov.x) >= Mathf.Abs(mov.y) && mov != Vector2.zero && !GameManager.instance.gameIsPaused)
        {
            anim.SetFloat("PosY", 0);
            if (mov.x >= 0) // Mirar Derecha
            {
                anim.SetFloat("PosX", 1);
                attackIndicator = 1;
            }
            else // Mirar Izquierda
            {
                anim.SetFloat("PosX", -1);
                attackIndicator = 2;
            }
        }

        else if (mov != Vector2.zero && !GameManager.instance.gameIsPaused)
        {
            anim.SetFloat("PosX", 0);
            if (mov.y >= 0) // Mirar Arriba
            {
                anim.SetFloat("PosY", 1);
                attackIndicator = 3;

            }
            else // Mirar Abajo
            {
                anim.SetFloat("PosY", -1);
                attackIndicator = 4;
                //Debug.Log(indicadorAtaque);

            }
        }

        anim.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().Play("Swing");
        switch (attackIndicator)
        {
            case 1:
                attackCollider.offset = new Vector2(0.3f, 0);
                break;
            case 2:
                attackCollider.offset = new Vector2(-0.3f, 0);
                break;
            case 3:
                attackCollider.offset = new Vector2(0, 0.2f);
                break;
            case 4:
                attackCollider.offset = new Vector2(0, -0.2f);
                break;
        }
    }
}

