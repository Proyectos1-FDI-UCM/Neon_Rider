using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyVision))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(Rigidbody2D))]

public class Turret : MonoBehaviour
{
    [SerializeField] float speed = 1f, move = 0f, changePos = 2.5f;
    Transform player;
    [SerializeField] Transform[] children = null;



    int rnd;
    EnemyAttack attack;
    EnemyVision vision;
    Enemy_Death death;




    void Awake()
    {
        player = GameManager.instance.GetPlayer().transform;
        vision = GetComponent<EnemyVision>();
        attack = GetComponent<EnemyAttack>();
        death = GetComponent<Enemy_Death>();
    }

    private void Start()
    {

        transform.DetachChildren();

        rnd = Random.Range(0, children.Length);

    }


    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, children[rnd].position, speed * Time.deltaTime);

        if (player != null)
        {
            if (Vector2.Distance(transform.position, children[rnd].position) < 0.2f)
            {
                if (move <= 0)
                {
                    move = changePos;
                    rnd = Random.Range(0, children.Length);
                }
                else
                {
                    death.enabled = false;
                    move -= Time.deltaTime;
                    if (vision.Spotted(player))
                        attack.enabled = true;
                    else
                        attack.enabled = false;
                }
            }
            else
            {
                death.enabled = true;
                attack.enabled = false;
            }
        }
    }
}