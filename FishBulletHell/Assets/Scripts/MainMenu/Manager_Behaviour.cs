using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Behaviour : MonoBehaviour
{
    public Transform maxUp;
    public Transform minDown;

    public GameObject alga1;
    public GameObject alga2;
    public GameObject alga3;
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;

    private float algaTimer;
    private float algaRandomTimer;
    
    void Start() {
        algaTimer = 0f;
        algaRandomTimer = Random.Range(0.0f, 2.0f);

    }
    
    void Update() {
        algaTimer += Time.deltaTime;
        manageExtras();
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
