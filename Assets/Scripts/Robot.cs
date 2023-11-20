using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float speed = 15;

    private Rigidbody2D rb;

    private int direction = 1;
    public bool vertical = false;

    private const float turnTime = 2;
    private float turnTimer;
   
    private Animator animator;

    private bool isBroken;

    // Start is called before the first frame update
    void Start()
    {
        turnTimer = turnTime;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if(vertical)
        {
            animator.SetFloat("MoveY", direction);
            animator.SetFloat("MoveX", 0);
        }
        else
        {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }
        
        isBroken = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBroken)
            return;


        Move();

        turnTimer -= Time.deltaTime;
        if (turnTimer < 0)
        {
            direction = -direction;
            if (vertical)
            {
                animator.SetFloat("MoveY", direction);
                animator.SetFloat("MoveX", 0);
            }
            else
            {
                animator.SetFloat("MoveX", direction);
                animator.SetFloat("MoveY", 0);
            }

            turnTimer = turnTime;
        }

    }
    private void Move()
    {
        Vector2 position = transform.position;
        if(vertical)
            position.y = direction * speed * Time.deltaTime + transform.position.y;     
        else
            position.x = direction * speed * Time.deltaTime + transform.position.x;

        rb.MovePosition(position);
    }
    public void Fix()
    {
        rb.simulated = false;
        isBroken = true;
        animator.SetTrigger("Fix");
    }
}
