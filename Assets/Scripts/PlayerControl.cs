using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 20;

    private Rigidbody2D rb;

    private int maxHp = 5;
    private int curHp = 0;

    private const float ineffTime = 2;
    public bool isIneff = false;
    public float ineffTimer;

    public int CurHp {  get { return curHp; } }
    public int MaxHp { get { return maxHp; } }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        ineffTimer = ineffTime;
        curHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(isIneff)
        {
            ineffTimer -= Time.deltaTime;
            if(ineffTimer < 0 )
            {
                isIneff = false;
            }
        }
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x = h * speed * Time.deltaTime + transform.position.x;
        position.y = v * speed * Time.deltaTime + transform.position.y;

        rb.MovePosition(position);
    }

    public void ChangeHp(int count)
    {
        if(count < 0)
        {
            if(isIneff)
                return;
            isIneff = true;
            ineffTimer = ineffTime;
        }

        curHp = Mathf.Clamp(curHp + count, 0, maxHp);
        Debug.Log(curHp + "/" + maxHp);
    }
}
