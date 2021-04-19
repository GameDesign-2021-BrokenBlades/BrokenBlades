using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 7f;
    public float jumpHeight = 12.5f;
    public GameObject camera;
    public bool isGrounded = false;
    public bool isWalledLeft = false;
    public bool isWalledRight = false;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            if (isWalledLeft == false && isWalledRight == false){
                transform.position += movement * Time.deltaTime * moveSpeed;
            }
            if (isWalledLeft == true & movement.x > 0){
                transform.position += movement * Time.deltaTime * moveSpeed;
            }
            if (isWalledRight == true & movement.x < 0) {
                transform.position += movement * Time.deltaTime * moveSpeed;
            }

            camera.transform.position = (transform.position + new Vector3(0f, 2.5f, -10));

            if (isGrounded == true) {
                Jump();
            }

    }

    void Jump(){
    if (Input.GetButtonDown("Jump")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }
}
