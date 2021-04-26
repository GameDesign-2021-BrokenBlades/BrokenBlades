using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask wallLayerMask;

    public float moveSpeed = 7f;
    public float jumpHeight = 12.5f;
    public GameObject camera;
    private Rigidbody2D rigidbody2d;
    private PolygonCollider2D polygonCollider2d;
    private Animator animator;

    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        polygonCollider2d = transform.GetComponent<PolygonCollider2D>();
        animator = transform.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        if (!isWalledLeft() && !isWalledRight())
        {
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        else if (isWalledLeft() & movement.x > 0)
        {
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        else if (isWalledRight() & movement.x < 0) 
        {
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        if (movement.x == 0) {
            animator.SetBool("isMoving", false);
        } else {
            animator.SetBool("isMoving", true);
        }

        
        animator.SetFloat("Movement", movement.x);
        camera.transform.position = (transform.position + new Vector3(0f, 2.5f, -10));

        if (isGrounded() && Input.GetButtonDown("Jump")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            animator.SetBool("grounded", false);
        } else if (isGrounded()) {
            animator.SetBool("grounded", true);
        }
    }

    private bool isGrounded() {
        float extraHeight = .2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(polygonCollider2d.bounds.center, polygonCollider2d.bounds.size, 0f, Vector2.down, extraHeight, groundLayerMask);
        Color rayColor;
        if (raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }
        Debug.DrawRay(polygonCollider2d.bounds.center, Vector2.down * (polygonCollider2d.bounds.extents.y + extraHeight), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;    
    }

    private bool isWalledLeft() {
        float extraWidth = .2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(polygonCollider2d.bounds.center, polygonCollider2d.bounds.size, 0f, Vector2.left, extraWidth, wallLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(polygonCollider2d.bounds.center, Vector2.left * (polygonCollider2d.bounds.extents.x + extraWidth), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    private bool isWalledRight()
    {
        float extraWidth = .2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(polygonCollider2d.bounds.center, polygonCollider2d.bounds.size, 0f, Vector2.right, extraWidth, wallLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(polygonCollider2d.bounds.center, Vector2.right * (polygonCollider2d.bounds.extents.x + extraWidth), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
}
