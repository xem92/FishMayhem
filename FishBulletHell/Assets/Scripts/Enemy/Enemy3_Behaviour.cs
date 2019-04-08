using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_Behaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    public GameObject bullet;
    public Transform firePos; // Front shot
    private float timer;
    private int health;

    private GameObject gameManager;

    public AudioClip hitClip;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
        timer = 0f;
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0];
        health = 6;
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer > 2.0f) {
            GameObject obj = Instantiate(bullet, firePos.position, Quaternion.identity);
            timer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Endscreen")) {
            gameManager.GetComponent<GameManager_BehaviourScript>().addPoints(-2);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("InfinityBullet")) {
            AudioManager_Script.instance.PlayHits(hitClip);
            health -= 4;
            if (health < 0) {
                gameManager.GetComponent<GameManager_BehaviourScript>().addPoints(10);
                Destroy(gameObject);
            }
        }

        if (col.gameObject.CompareTag("Bullet")) {
            AudioManager_Script.instance.PlayHits(hitClip);
            health--;
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
