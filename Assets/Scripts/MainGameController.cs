using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour {





    //Camera mainCamera;
    
    int level = 0;
    int levelSectionAdded;
    int levelSectionMax;
    GameObject prevLevelSection;
    GameObject curLevelSection;
    GameObject nextLevelSection;
    GameObject postcatObj;
    GameObject checkpoint;
    public Transform postcatPrefab;
    public Transform levelSectionPrefab;
    public Transform checkPointPrefab;

    void Start() {
        InstantiateFisrtsCheckPoint();
        InstantiatePostcatNoRope();
        prevLevelSection = null;
        curLevelSection = checkpoint;
        SetupLevel();
    }
    void InstantiateFisrtsCheckPoint() {
        checkpoint = Instantiate(
            checkPointPrefab,
            new Vector3(1f,1f,0f),
            Quaternion.identity).gameObject;
    }
    void InstantiatePostcatNoRope() {
        postcatObj = Instantiate(
            postcatPrefab,
            checkpoint.transform.position,
            checkpoint.transform.rotation).gameObject;
        Camera.main.GetComponent<MainCameraController>().target = postcatObj.transform;
    }

    void SetupLevel() {
        LevelController temp_lv = new LevelController(level);
        levelSectionMax = temp_lv.maxSectionNumber;
        if (prevLevelSection != null) {
            NextSection();
        } else {
            InstantiateSection();
        }
        levelSectionAdded = 1;
        LevelSectionController.playerEnterSection += this.NextSection;

    }
    void InstantiateSection() {
        float SectionPositionX = curLevelSection.transform.position.x;
        float SectionWidthX = curLevelSection.GetComponent<BoxCollider2D>().bounds.size.x;
        nextLevelSection = Instantiate(levelSectionPrefab, new Vector3(SectionPositionX + SectionWidthX, 1f, 0f), Quaternion.identity).gameObject;
       
    }
    //void Destroy

    void NextSection() {
        DestroyObject(prevLevelSection);
        prevLevelSection = curLevelSection;
        curLevelSection = nextLevelSection;
        float LevelPositionX = curLevelSection.GetComponent<Collider2D>().bounds.size.x + curLevelSection.transform.position.x + 0.1f;
        nextLevelSection = Instantiate(levelSectionPrefab, new Vector3(LevelPositionX, 1f, 0f), Quaternion.identity).gameObject;
        levelSectionAdded++;
    }
    public void NextLevel() {
        level++;
        Debug.Log("You cool" + level.ToString());
        CheckPointController.playerRichCheckPoint -= this.NextLevel;
        DestroyObject(prevLevelSection);
        prevLevelSection = curLevelSection;
        curLevelSection = nextLevelSection;
        nextLevelSection = checkpoint;
        SetupLevel();
    }
    private void FixedUpdate() {
        if (levelSectionAdded == levelSectionMax) {
            levelSectionAdded++;
            DrawCheckPoint();
        }
    }
    void DrawCheckPoint() {
        float LevelPositionX = nextLevelSection.GetComponent<Collider2D>().bounds.size.x + nextLevelSection.transform.position.x + 0.1f;
        checkpoint = Instantiate(checkPointPrefab, new Vector3(LevelPositionX, 1f, 0), Quaternion.identity).gameObject;
        LevelSectionController.playerEnterSection -= this.NextSection;
        CheckPointController.playerRichCheckPoint += this.NextLevel;
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

