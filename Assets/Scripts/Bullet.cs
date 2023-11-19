using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Robot robot = collision.gameObject.GetComponent<Robot>();
        if (robot != null)
        {
            robot.Fix();
        }
        Destroy(gameObject);
    }
}
