using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerControl playerControl = collision.GetComponent<PlayerControl>();
        if (collision.tag == "Player" && playerControl != null)
        {
            playerControl.ChangeHp(-1);
        }
    }
}
