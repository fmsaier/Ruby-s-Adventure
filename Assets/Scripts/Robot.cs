using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float speed = 15;

    private Rigidbody2D rb;

    private int direction = 1;

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
        animator.SetFloat("MoveX", direction);
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
            animator.SetFloat("MoveX", direction);
            turnTimer = turnTime;
        }

    }
    private void Move()
    {
        Vector2 position = transform.position;
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
