using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    GameState state;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
            //player.body.MovePosition(new Vector2(0, 0));
    }
}
