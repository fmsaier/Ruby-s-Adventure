using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 20;

    private Rigidbody2D rb;
    //private Rigidbody2D enRb;

    private int maxHp = 5;
    private int curHp = 0;

    private const float ineffTime = 2;
    public bool isIneff = false;
    public float ineffTimer;

    //public GameObject enemy;

    private Animator animator;
    Vector2 dir = new Vector2(0, 1);

    public GameObject bulletPrefab;
    public int force = 300;

    public int CurHp {  get { return curHp; } }
    public int MaxHp { get { return maxHp; } }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        ineffTimer = ineffTime;
        curHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
        //enRb = enemy.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //enRb.AddForce(new Vector2(10,0));

        Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (isIneff)
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

        Vector2 pos = new Vector2(h, v);

        //控制（0，0）的朝向，让上一次向哪走最后就面向哪，防止被初始化成（0，0）
        if (!Mathf.Approximately(pos.x, 0) || !Mathf.Approximately(pos.y, 0))
        {
            dir = pos;
            //单位向量，让混合树精准匹配到位置
            dir.Normalize();
        }

        animator.SetFloat("Look X", dir.x);
        animator.SetFloat("Look Y", dir.y);
        animator.SetFloat("Speed", pos.magnitude);

        Vector2 position = transform.position;
        position = pos * speed * Time.deltaTime + position;

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
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(force * dir);
        animator.SetTrigger("Launch");
    }
}
