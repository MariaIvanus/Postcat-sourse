using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_VER1 : MonoBehaviour {

    Camera mainCamera;
    public Transform startPoint;
    int level = 1;
    int LevelSectionPassed = 1; //zero at lvl start, equal to Section passed, multiplying so 1 not 0
    float LevelSectionWidth; // Узнавать для каждого элемента а не фиксированую

    int levelSectionMax;
    GameObject prevLevelSection;
    GameObject curLevelSection;
    GameObject nextLevelSection;
    GameObject postcatObj; //it`s position will be somewhere near middle of the screen
    public Transform postcatPrefab;
    public Transform levelSectionPrefab;
    public Transform checkpointtPrefab;

    //харнить чекпоинт в памяти и рисовать его сразу, а как толко игрок улетит отдалить...



    void Start() {

        //ORDER IMPORTANT
        SetupLevel();
        InstantiatePostcatNoRope();
        InstantiateCamera();
        InstantiateSection();

    }
    void SetupLevel() {
        LevelController temp_lv = new LevelController(level);
        levelSectionMax = temp_lv.maxSectionNumber;
    }

    void InstantiatePostcatNoRope() {
        GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");
        //DO SMTH IF RESp NULL
        if (respawn == null) {
            Debug.Log("null");
        } else {
            Debug.Log("not null");
        }
        startPoint = respawn.transform;
        //Debug.Log(respawn.transform.position.x.ToString() + " " + respawn.transform.position.y.ToString());
        //Debug.Log(startPoint.position.x.ToString() + " " + startPoint.position.y.ToString());
        postcatObj = Instantiate(
            postcatPrefab,
            respawn.transform.position,
            respawn.transform.rotation).gameObject;

        // Push Postcat away from the station.
        // postcatObj.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 20.0f, ForceMode2D.Impulse);
        //yield return null;
    }

    void InstantiateCamera() {
        mainCamera = Camera.main;
        mainCamera.GetComponent<MainCameraController>().target = postcatObj.transform;
        //TODO: ширина экрана - вынести в функцию, где переопредиляется ширина.
        LevelSectionWidth = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f)).x * 2;
    }

    //draw first sections for level
    void InstantiateSection() {
        prevLevelSection = null;
        curLevelSection = Instantiate(levelSectionPrefab, new Vector3(postcatObj.transform.position.x, postcatObj.transform.position.y - 2, 0), Quaternion.identity).gameObject;
        nextLevelSection = Instantiate(levelSectionPrefab, new Vector3(postcatObj.transform.position.x + LevelSectionWidth, postcatObj.transform.position.y - 2, 0), Quaternion.identity).gameObject;
    }

    private void FixedUpdate() {
        //пройденая котом дистанция.
        float CatPassDistance = Vector3.Distance(startPoint.position, postcatObj.transform.position);

        //Если секция пройдена 

        if (CatPassDistance >= LevelSectionWidth * LevelSectionPassed) {
            LevelSectionPassed++;
            Debug.Log(LevelSectionPassed + " " + levelSectionMax);
            Debug.Log("Cond" + (LevelSectionWidth * LevelSectionPassed).ToString());
            if (LevelSectionPassed == levelSectionMax) {
                Debug.Log("CatPassDistance" + CatPassDistance.ToString());
                //нарисовать чекпоинт с оффсетом и когда достигнут чекпоинт тригерить следующий уровень.
                NextLevel();
            } else {
                DrawNextSectiion();
                DeletePrevSection();
            }
        }
    }
    void NextLevel() {
        PauseOn();
        level++;
        startPoint.position = postcatObj.transform.position;


        LevelSectionPassed = 1;
        Debug.Log("You cool" + level.ToString());
        float LevelPositionX = postcatObj.transform.position.x + LevelSectionWidth;
        Instantiate(checkpointtPrefab, new Vector3(LevelPositionX, postcatObj.transform.position.y - 2, 0), Quaternion.identity);
        SetupLevel();
        PauseOff();


    }

    void DrawNextSectiion() {
        float LevelPositionX = postcatObj.transform.position.x + LevelSectionWidth;
        prevLevelSection = curLevelSection;
        curLevelSection = nextLevelSection;
        nextLevelSection = Instantiate(levelSectionPrefab, new Vector3(LevelPositionX, postcatObj.transform.position.y - 2, 0), Quaternion.identity).gameObject;
    }
    void DeletePrevSection() {
        DestroyObject(prevLevelSection);
    }

    private bool isPaused;
    public void PauseOn() {
        Time.timeScale = 0.0f;
        isPaused = true;
    }
    public void PauseOff() {
        Time.timeScale = 1.0f;
        isPaused = false;
    }
}

