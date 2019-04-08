using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Behaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Endscreen")) {
            Destroy(gameObject);
        }
    }
}
