using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedScale = 10.0f;
    //public float maxSpeed = 10.0f;
    //public float consumption = 0.1f;
    //public float fuel = 100.0f;

   // public float yBound = 8.0f;
   // public float reboundForce = 1.0f;
    //public float clampVelScale = 1.0f;

    Rigidbody2D rb;
   // Animator animator;
   // GameController gameController;

    void Awake() {
       // Debug.Log("Kit controller");
        rb = GetComponent<Rigidbody2D>();
        /*animator = GetComponentInChildren<Animator>();
        gameController = GameObject
            .Find("GameController")
            .gameObject
            .GetComponent<GameController>();*/
    }

    // Update is called once per frame
    void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, v, 0.0f);
       // Debug.Log(h.ToString() + " " + v.ToString());
        rb.AddForce(movement * speedScale);
        //Rota

    }
}
