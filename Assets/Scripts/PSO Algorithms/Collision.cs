using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    void Start()
    {
        
    }

    // Checks for collision on flock agent
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //on collision player object is found because that is the only collision that matters.
        Player player = GameObject.Find("Player").GetComponent<Player>();
        //check to see if collision is with player
        if (collision.gameObject.name == "Player")
        {
            //if true then the object has collided with the player and the player loses health.
            player.Alterhealth(-10);
        }
        //check to see if collision is with the arrow
        else if (collision.gameObject.tag == "Arrow")
        {
            //if true then gameobject is destroyed and the player is awarded coins.
            gameObject.SetActive(false);
            player.AlterCoins(50);
            Destroy(gameObject);
        }
    }

}
