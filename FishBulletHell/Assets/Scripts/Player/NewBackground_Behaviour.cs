using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBackground_Behaviour : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject newBG;
    public Transform spawnPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("BG")) {
            Instantiate(newBG, spawnPos.position, Quaternion.identity);
        }
    }
}
