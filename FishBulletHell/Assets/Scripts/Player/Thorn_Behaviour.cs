using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn_Behaviour : MonoBehaviour {

    public float lifetime = 3f;
    public float velocity = 10f;
    private Rigidbody2D rb2d;
    private float xDir;
    private float yDir;

    public void setParams(float xDir, float yDir) {
        this.xDir = xDir;
        this.yDir = yDir;
    }

    void Start() {
        Destroy(gameObject, lifetime);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(10f * xDir, 10f * yDir);
    }
}
