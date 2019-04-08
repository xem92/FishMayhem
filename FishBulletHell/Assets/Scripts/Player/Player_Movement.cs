using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour {

    public float speed = 1.0f;
    private float maxPosSpeed = 5f;
    private float maxNegSpeed = -7f;
    private Rigidbody2D rb2d;
    public int powerUp; // 0: Normal, 1: pez globo, 2: pez espada, 3: pez luna
    private int health;

    private float timer = 3f;
    public GameObject bullet;
    public GameObject thorn;
    public GameObject sword;
    public GameObject bfb;
    public Transform firePos; // Front shot
    public Transform firePos1; // 15º shot
    public Transform firePos2; // 30º shot
    public Transform firePos3; // 45º shot
    public Transform firePos4; // 60º shot
    public Transform firePos5; // -15º shot
    public Transform firePos6; // -30º shot
    public Transform firePos7; // -45º shot
    public Transform firePos8; // -60º shot

    Rect topLeft;
    Rect bottomLeft;
    Rect right;

    private float maxUp = 4.5f;
    private float minDown = -4.5f;

    private Image heart1;
    private Image heart2;
    private Image heart3;

    private GameObject gameManager;

    private Animator animator;

    public AudioClip[] clipsShooting;
    public AudioClip hitClip;
    public AudioClip powerUpClip;
    public AudioClip healthClip;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        health = 2;
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0];

        GameObject heartGO = GameObject.FindGameObjectWithTag("Heart1");
        if (heartGO != null) {
            heart1 = heartGO.GetComponent<Image>();
        }
        heartGO = GameObject.FindGameObjectWithTag("Heart2");
        if (heartGO != null) {
            heart2 = heartGO.GetComponent<Image>();
        }
        heartGO = GameObject.FindGameObjectWithTag("Heart3");
        if (heartGO != null) {
            heart3 = heartGO.GetComponent<Image>();
        }

        animator = GetComponent<Animator>();

        topLeft = new Rect(0, 0, Screen.width / 2, Screen.height / 2);
        bottomLeft = new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2);
        right = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2);
    }
    
    void Update() {
        updateMovementKeyboardInput();
        updateTouchInput();
        updateShootKeyboardInput();
        
        if (gameObject.transform.position.y > maxUp) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, maxUp, gameObject.transform.position.z);
            rb2d.velocity = Vector2.up * 0f;
        }
        if (gameObject.transform.position.y < minDown) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, minDown, gameObject.transform.position.z);
            rb2d.velocity = Vector2.up * 0f;
        }
    }

    void updateTouchInput() {
        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; i++) {
                Touch touch = Input.GetTouch(i);
                if (topLeft.Contains(touch.position)) {
                    setVelocity(1.0f * speed);
                }
                if (bottomLeft.Contains(touch.position)) {
                    setVelocity(-1.0f * speed);
                }
                if (right.Contains(touch.position)) {
                    fire();
                }
            }
        }
    }

    void setVelocity(float input) {
        Vector2 vel = rb2d.velocity + Vector2.up * Time.deltaTime * input;
        if (vel.y > maxPosSpeed) {
            rb2d.velocity = Vector2.up * maxPosSpeed;
        }
        else if (vel.y <= maxNegSpeed) {
            rb2d.velocity = Vector2.up * maxNegSpeed;
        }
        else {
            rb2d.velocity = vel;
        }
    }

    void updateMovementKeyboardInput() {
        float inputY = -Input.GetAxis("Vertical") * speed;
        Vector2 vel = rb2d.velocity + Vector2.up * Time.deltaTime * inputY;
        if (vel.y > maxPosSpeed) {
            rb2d.velocity = Vector2.up * maxPosSpeed;
        }
        else if (vel.y <= maxNegSpeed) {
            rb2d.velocity = Vector2.up * maxNegSpeed;
        }
        else {
            rb2d.velocity = vel;
        }
    }

    void updateShootKeyboardInput() {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)) {
            fire();
        }
    }

    void fire() {
        switch (powerUp) {
            case 0:
                fireType0();
                break;
            case 1:
                fireType1();
                break;
            case 2:
                fireType2();
                break;
            case 3:
                fireType3();
                break;
        }
    }

    void fireType0() {
        if (timer > 0.1f) {
            AudioManager_Script.instance.PlayBullet(clipsShooting[0]);
            GameObject obj = Instantiate(bullet, firePos.position, Quaternion.identity);
            timer = 0f;
        }
    }

    void fireType1() {
        if (timer > 0.5f) {
            AudioManager_Script.instance.PlayBullet(clipsShooting[1]);
            GameObject obj = Instantiate(thorn, firePos.position, Quaternion.identity);
            obj.GetComponent<Thorn_Behaviour>().setParams(1.0f, 0.0f);
            obj.GetComponent<Thorn_Behaviour>().transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f));
            obj = Instantiate(thorn, firePos1.position, Quaternion.identity);
            obj.GetComponent<Thorn_Behaviour>().setParams(0.97f, 0.25f);
            obj.GetComponent<Thorn_Behaviour>().transform.Rotate(new Vector3(0.97f, 0.25f, 0.0f));
            obj = Instantiate(thorn, firePos2.position, Quaternion.identity);
            obj.GetComponent<Thorn_Behaviour>().setParams(0.86f, 0.5f);
            obj.GetComponent<Thorn_Behaviour>().transform.Rotate(new Vector3(0.86f, 0.5f, 0.0f));
            obj = Instantiate(thorn, firePos3.position, Quaternion.identity);
            obj.GetComponent<Thorn_Behaviour>().setParams(0.7f, 0.7f);
            obj.GetComponent<Thorn_Behaviour>().transform.Rotate(new Vector3(0.7f, 0.7f, 0.0f));
            obj = Instantiate(thorn, firePos4.position, Quaternion.identity);
            obj.GetComponent<Thorn_Behaviour>().setParams(0.5f, 0.86f);
            obj.GetComponent<Thorn_Behaviour>().transform.Rotate(new Vector3(0.5f, 0.86f, 0.0f));
            obj = Instantiate(thorn, firePos5.position, Quaternion.identity);
            obj.GetComponent<Thorn_Behaviour>().setParams(0.97f, -0.25f);
            obj.GetComponent<Thorn_Behaviour>().transform.Rotate(new Vector3(0.97f, -0.25f, 0.0f));
            obj = Instantiate(thorn, firePos6.position, Quaternion.identity);
            obj.GetComponent<Thorn_Behaviour>().setParams(0.86f, -0.5f);
            obj.GetComponent<Thorn_Behaviour>().transform.Rotate(new Vector3(0.86f, -0.5f, 0.0f));
            obj = Instantiate(thorn, firePos7.position, Quaternion.identity);
            obj.GetComponent<Thorn_Behaviour>().setParams(0.7f, -0.7f);
            obj.GetComponent<Thorn_Behaviour>().transform.Rotate(new Vector3(0.7f, -0.7f, 0.0f));
            obj = Instantiate(thorn, firePos8.position, Quaternion.identity);
            obj.GetComponent<Thorn_Behaviour>().setParams(0.5f, -0.86f);
            obj.GetComponent<Thorn_Behaviour>().transform.Rotate(new Vector3(0.5f, -0.86f, 0.0f));
            timer = 0f;
        }
    }

    void fireType2() {
        if (timer > 0.5f) {
            AudioManager_Script.instance.PlaySword(clipsShooting[2]);
            GameObject obj = Instantiate(sword, firePos.position, Quaternion.identity);
            timer = 0f;
        }
    }

    void fireType3() {
        if (timer > 1.0f) {
            AudioManager_Script.instance.PlayBullet(clipsShooting[3]);
            GameObject obj = Instantiate(bfb, firePos.position, Quaternion.identity);
            timer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Enemy")) {
            AudioManager_Script.instance.PlayHits(hitClip);
            gameManager.GetComponent<GameManager_BehaviourScript>().addPoints(-15);
            Destroy(col.gameObject);
            health--;
            updateHealth();
            if (health < 0) {
                Destroy(gameObject);
                gameManager.GetComponent<GameManager_BehaviourScript>().GameOver();
            }
        }

        if (col.gameObject.CompareTag("Life")) {
            AudioManager_Script.instance.PlayPowerups(healthClip);
            Destroy(col.gameObject);
            health++;
            updateHealth();
        }

        if (col.gameObject.CompareTag("Powerup0")) {
            AudioManager_Script.instance.PlayPowerups(powerUpClip);
            Destroy(col.gameObject);
            animator.SetInteger("PowerUp", 0);
            setPowerUp(0);
        }

        if (col.gameObject.CompareTag("Powerup1")) {
            AudioManager_Script.instance.PlayPowerups(powerUpClip);
            Destroy(col.gameObject);
            animator.SetInteger("PowerUp", 1);
            setPowerUp(1);
        }

        if (col.gameObject.CompareTag("Powerup2")) {
            AudioManager_Script.instance.PlayPowerups(powerUpClip);
            Destroy(col.gameObject);
            animator.SetInteger("PowerUp", 2);
            setPowerUp(2);
        }

        if (col.gameObject.CompareTag("Powerup3")) {
            AudioManager_Script.instance.PlayPowerups(powerUpClip);
            Destroy(col.gameObject);
            animator.SetInteger("PowerUp", 3);
            setPowerUp(3);
        }
    }

    public void setPowerUp(int powerUp) {
        this.powerUp = powerUp;
    }

    public int getPowerUp() {
        return this.powerUp;
    }

    public int getHealth() {
        return this.health;
    }

    private void updateHealth() {
        switch (health) {
            case 2:
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
                break;
            case 1:
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = false;
                break;
            case 0:
                heart1.enabled = true;
                heart2.enabled = false;
                heart3.enabled = false;
                break;
            default:
                heart1.enabled = false;
                heart2.enabled = false;
                heart3.enabled = false;
                break;
        }
    }
}
