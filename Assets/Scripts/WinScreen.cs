using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // CheckPointController.playerRichCheckPoint += this.ShowWinScreen;
        //this.gameObject.visi
    }
	
	// Update is called once per frame
	public void ShowWinScreen () {
        Debug.Log("WIN SCREEN");
        this.gameObject.SetActive(true);
	}
    void ToNextLvl() {

    }
    void ToRestart() {

    }
    void ShowLoseScreen() {

    }
}
