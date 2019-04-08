using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFB_Behaviour : MonoBehaviour {
    public float lifetime = 3f;
    public float velocity = 10f;
    private Rigidbody2D rb2d;

    void Start() {
        Destroy(gameObject, lifetime);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(10f, 0f);
    }
}
