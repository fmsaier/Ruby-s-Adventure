using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl playerControl = collision.GetComponent<PlayerControl>();
        if(collision.tag == "Player" && playerControl != null)
        {
            if(playerControl.CurHp < playerControl.MaxHp)
            {
                playerControl.ChangeHp(1);
                Destroy(gameObject);
            }
        }
    }
}
