using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSectionController : MonoBehaviour {

    public delegate void OnCheckPointHandler();
    public static event OnCheckPointHandler playerEnterSection;
    //public static event OnCheckPointHandler playerExitSection;

    private bool playerEnterThis = false;
    //private bool playerExitThis = false;
    void Start() {

    }
   
    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("chek");
        if (playerEnterThis == false && collision.gameObject.CompareTag("Player")) {
            //Debug.Log("enter");
            if (playerEnterSection != null) {
                playerEnterSection();
                playerEnterThis = true;
            }

        }
    }
}
