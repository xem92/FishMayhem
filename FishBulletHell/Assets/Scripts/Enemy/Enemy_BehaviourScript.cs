using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BehaviourScript : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 2f;
    private int health;

    private GameObject gameManager;

    public AudioClip hitClip;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0];
        health = 6;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Endscreen")) {
            gameManager.GetComponent<GameManager_BehaviourScript>().addPoints(-2);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("InfinityBullet")) {
            health -= 5;
            AudioManager_Script.instance.PlayHits(hitClip);
            if (health < 0) {
                gameManager.GetComponent<GameManager_BehaviourScript>().addPoints(10);
                Destroy(gameObject);
            }
        }

        if (col.gameObject.CompareTag("Bullet")) {
            health--;
            AudioManager_Script.instance.PlayHits(hitClip);
            if (health < 0) {
                gameManager.GetComponent<GameManager_BehaviourScript>().addPoints(10);
                Destroy(gameObject);
            }
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("SwordBullet")) {
            AudioManager_Script.instance.PlayHits(hitClip);
            gameManager.GetComponent<GameManager_BehaviourScript>().addPoints(10);
            Destroy(gameObject);
        }
    }
}
