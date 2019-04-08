using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_BehaviourScript : MonoBehaviour {

    public float delay = 1f;
    public Transform maxUp;
    public Transform minDown;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject life;
    public GameObject powerup0;
    public GameObject powerup1;
    public GameObject powerup2;
    public GameObject powerup3;
    public GameObject alga1;
    public GameObject alga2;
    public GameObject alga3;
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;

    private float newPos;

    private float enemyTimer;
    private float powerTimer;
    private float healthTimer;
    private float gameTimer;
    private float algaTimer;

    private float algaRandomTimer;

    public int points;
    public Text score;

    private GameObject player;

    public Canvas gameOverCanvas;
    public Canvas gameCanvas;
    public Text finalScore;

    public AudioClip levelMusic;

    void Start() {
        enemyTimer = 0f;
        powerTimer = 0f;
        healthTimer = 0f;
        gameTimer = 0f;
        algaTimer = 0f;

        algaRandomTimer = Random.Range(0.0f, 2.0f);

        player = GameObject.Find("Fish");
        points = 0;

        gameOverCanvas.enabled = false;
        gameCanvas.enabled = true;

        AudioManager_Script.instance.PlayMusic(levelMusic);
    }

    void Update() {
        enemyTimer += Time.deltaTime;
        powerTimer += Time.deltaTime;
        healthTimer += Time.deltaTime;
        gameTimer += Time.deltaTime;
        algaTimer += Time.deltaTime;

        manageEnemy();
        managePower();
        manageLife();
        manageExtras();
    }

    private void manageEnemy() {
        float enemyDelay = getEnemyDelay();
        if (enemyTimer > enemyDelay) {
            newPos = Random.Range(maxUp.position.y, minDown.position.y);
            Vector3 spawnPos = new Vector3(11f, newPos, 0f);
            int en = Random.Range(0, 10);
            switch (en) {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    Instantiate(enemy, spawnPos, Quaternion.identity);
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    Instantiate(enemy3, spawnPos, Quaternion.identity);
                    break;
                case 9:
                    Instantiate(enemy2, spawnPos, Quaternion.identity);
                    break;
                default:
                    Instantiate(enemy, spawnPos, Quaternion.identity);
                    break;
            }
            enemyTimer = 0f;
        }
    }

    private void managePower() {
        if (player != null) {
            if (powerTimer > 15.0f) {
                int powerup = player.GetComponent<Player_Movement>().getPowerUp();
                spawnPowerup(powerup);
            }
        }
    }

    private void spawnPowerup(int actualPowerup) {
        int newPower = Random.Range(0, 4);
        if (newPower != actualPowerup) {
            powerTimer = 0.0f;
            float newPos = Random.Range(maxUp.position.y, minDown.position.y);
            Vector3 spawnPos = new Vector3(11f, newPos, 0f);
            switch (newPower) {
                case 0:
                    Instantiate(powerup0, spawnPos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(powerup1, spawnPos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(powerup2, spawnPos, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(powerup3, spawnPos, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }

    private void manageLife() {
        if (player != null) {
            int health = player.GetComponent<Player_Movement>().getHealth();
            switch (health) {
                case 0:
                    if (healthTimer > 5.0f) {
                        spawnHealth(-5.0f);
                    }
                    break;
                case 1:
                    if (healthTimer > 10.0f) {
                        spawnHealth(-10.0f);
                    }
                    break;
                default:
                    break;
            }
        }
    }
    
    private void spawnHealth(float newHealthTime) {
        float newPos = Random.Range(maxUp.position.y, minDown.position.y);
        Vector3 spawnPos = new Vector3(11f, newPos, 0f);
        Instantiate(life, spawnPos, Quaternion.identity);
        healthTimer = newHealthTime;
    }

    private float getEnemyDelay() {
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

    public void addPoints(int pointsToAdd) {
        points += pointsToAdd;
        score.text = "Score:\n" + points;
    }

    public void GameOver() {
        Time.timeScale = 0;
        gameOverCanvas.enabled = true;
        gameCanvas.enabled = false;
        finalScore.text = "Score: " + points;
    }

    private void manageExtras() {
        if (algaTimer > algaRandomTimer) {
            algaTimer = 0.0f;
            algaRandomTimer = Random.Range(0.0f, 2.0f);
            float newPos = Random.Range(maxUp.position.y, minDown.position.y);
            Vector3 spawnPos = new Vector3(11f, newPos, 0f);
            int extra = Random.Range(0, 6);
            switch (extra) {
                case 0:
                    Instantiate(alga1, spawnPos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(alga2, spawnPos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(alga3, spawnPos, Quaternion.identity);
                    break;
                case 3:
                    spawnPos = new Vector3(11f, -4f, 0f);
                    Instantiate(rock1, spawnPos, Quaternion.identity);
                    break;
                case 4:
                    spawnPos = new Vector3(11f, -4f, 0f);
                    Instantiate(rock2, spawnPos, Quaternion.identity);
                    break;
                case 5:
                    spawnPos = new Vector3(11f, -4f, 0f);
                    Instantiate(rock3, spawnPos, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }
}
