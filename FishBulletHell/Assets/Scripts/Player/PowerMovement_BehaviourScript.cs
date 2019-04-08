using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMovement_BehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    private float time;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
        time = 0f;
    }

    void Update() {
        time += Time.fixedDeltaTime;
        rb.MoveRotation(100f * time);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Endscreen")) {
            Destroy(gameObject);
        }
    }
}
