using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Behaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    public GameObject bullet;
    public Transform firePos; // Front shot
    private float timer;
    private float shootTimer;
    private int health;

    private GameObject gameManager;

    public AudioClip hitClip;

    private float maxUp = 4.5f;
    private float minDown = -4.5f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        timer = 0f;
        shootTimer = 0f;
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0];
        health = 6;
    }

    void Update() {
        timer += Time.deltaTime;
        shootTimer += Time.deltaTime;
        float up_speed = Mathf.Cos(timer * 2f) * 4f;
        rb.velocity = new Vector2(-speed, up_speed);

        if (gameObject.transform.position.y > maxUp) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, maxUp, gameObject.transform.position.z);
            rb.velocity = Vector2.up * 0f;
        }
        if (gameObject.transform.position.y < minDown) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, minDown, gameObject.transform.position.z);
            rb.velocity = Vector2.up * 0f;
        }
        if (shootTimer > 2.0f) {
            GameObject obj = Instantiate(bullet, firePos.position, Quaternion.identity);
            shootTimer = 0f;
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
