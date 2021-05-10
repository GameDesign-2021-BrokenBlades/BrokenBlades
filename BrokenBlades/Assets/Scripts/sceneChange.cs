using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask playerLayerMask;

    void Start()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneChangeCollision()) {
            SceneManager.LoadScene(1);
        }
    }

    private bool sceneChangeCollision() {

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.up, .0f, playerLayerMask);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
}
