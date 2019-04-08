using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour {

    public float delay = 1f;
    public Transform maxUp;
    public Transform minDown;
    public GameObject enemy;
    public float newPos;
    public float timer;
    public float gameTimer;
    
    void Start() {
        timer = 3f;
        gameTimer = 0f;
    }
    
    void Update() {
        timer += Time.deltaTime;
        gameTimer += Time.deltaTime;
        float a = getDelay();
        if (timer > a) {
            newPos = Random.Range(maxUp.position.y, minDown.position.y);
            Vector3 spawnPos = new Vector3(11f, newPos, 0f);
            Instantiate(enemy, spawnPos, Quaternion.identity);
            timer = 0f;
        }
    }

    private float getDelay() {
        if (gameTimer < 10f) {
            return 5f;
        }
        if (gameTimer < 30f) {
            return 3f;
        }
        if (gameTimer < 50f) {
            return 1f;
        }
        if (gameTimer < 70f) {
            return 0.5f;
        }
        if (gameTimer < 90f) {
            return 0.3f;
        }
        return 1f;
    }
}
