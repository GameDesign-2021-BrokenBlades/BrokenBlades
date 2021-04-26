using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCollisionRight : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Walls")
        {
            player.GetComponent<player_movement>().isWalledRight = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Walls")
        {
            player.GetComponent<player_movement>().isWalledRight = false;
        }
    }
}
