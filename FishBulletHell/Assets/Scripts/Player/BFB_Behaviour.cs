﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFB_Behaviour : MonoBehaviour {
    public float velocity = 10f;
    private Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(10f, 0f);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Endscreen2")) {
            Destroy(gameObject);
        }
    }
}
