using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerControl playerControl = collision.gameObject.GetComponent<PlayerControl>();
        if (collision.gameObject.tag == "Player" && playerControl != null)
        {
            playerControl.ChangeHp(-1);
        }
    }
}
