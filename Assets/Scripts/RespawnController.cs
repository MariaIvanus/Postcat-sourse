using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour {

    public delegate void OnCheckPointHandler();
    public static event OnCheckPointHandler playerRespawn;

    void Start() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("chek");
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("chek");
            if (playerRespawn != null) {
                playerRespawn();
            }

        }
    }

}
