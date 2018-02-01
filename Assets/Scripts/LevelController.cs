using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelController{

    private int level;
    private int _maxSectionNumber;
    private int[] lvlsMaxLenght;

    // Use this for initialization
    public LevelController(int levelNumber) {
        this.level = levelNumber;

        lvlsMaxLenght = new[] { 6, 7, 5, 8, 11, 8, 9, 13 };


        GenerateLevel();
    }

    public int maxSectionNumber {
        get {
            return _maxSectionNumber;
        }
    }
    
    
	void GenerateLevel () {
        if (this.level < lvlsMaxLenght.Length) {
            _maxSectionNumber = lvlsMaxLenght[level];
        } else {
            _maxSectionNumber = (int) Mathf.Round(Random.Range(8, 16));
           
        }
       // Debug.Log("Distance " + _maxSectionNumber);
    }


}

