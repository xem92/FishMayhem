using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager_BehaviourScript : MonoBehaviour {

    public float delay = 1f;
    public Transform maxUp;
    public Transform minDown;
    public GameObject life;
    public GameObject powerup0;
    public GameObject powerup1;
    public GameObject powerup2;
    public GameObject powerup3;
    public float newPos;
    public float timer;
    public float gameTimer;

    void Start() {
        timer = 0f;
        gameTimer = 0f;
    }

    void Update() {
        timer += Time.deltaTime;
        gameTimer += Time.deltaTime;
        float a = getDelay();
        if (timer > a) {
            newPos = Random.Range(maxUp.position.y, minDown.position.y);
            Vector3 spawnPos = new Vector3(11f, newPos, 0f);
            Instantiate(powerup0, spawnPos, Quaternion.identity);
            timer = 0f;
        }
    }

    private float getDelay() {
        if (gameTimer < 10f) {
            return 5f;
        }
        return 1f;
    }
}
