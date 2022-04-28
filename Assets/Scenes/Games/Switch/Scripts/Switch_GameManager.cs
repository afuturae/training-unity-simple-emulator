using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Switch_GameManager : MonoBehaviour
{

    public GameObject player;
    public string nextStage;

    public GameObject respawn;

    [Header("Texts")]
    public TMP_Text txtScoreboard;
    private int scoreboard=0;
    public TMP_Text txtDeathCounter;
    private int deathCounter=0;

    [Header("Floors")]
    public GameObject floorBluePrefab;
    GameObject[] floorsBlue;
    
    public GameObject floorRedPrefab;
    GameObject[] floorsRed;

    private void Awake()
    {
        LoadSceneData();
        

        txtScoreboard.text = $"Flowers: {scoreboard}";
        txtDeathCounter.text = $"Deaths: {deathCounter}";
        
    }
    void Start()
    {
        floorsBlue = GameObject.FindGameObjectsWithTag("Floor_Blue");
        floorsRed = GameObject.FindGameObjectsWithTag("Floor_Red");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DetectFloor();
        NextStage();
        DieZone();        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetGame();
            Switch_MenuManager.BackToMenu();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ResetGame();
            Switch_MenuManager.QuitGame();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ResetGame();
            SceneManager.LoadScene("Switch_Stage1");
        }
    }

    void DetectFloor() {        
        if (GetColor(player) == GetColor(floorBluePrefab)){
            PassFloor(floorsBlue);
            NotPassFloor(floorsRed);
        }else if (GetColor(player) == GetColor(floorRedPrefab))
        {
            PassFloor(floorsRed);
            NotPassFloor(floorsBlue);
        }
        else
        {
            NotPassFloor(floorsBlue);
            NotPassFloor(floorsRed);
        }
    }

    void PassFloor(GameObject[] floors)
    {
        foreach (GameObject floor in floors)
        {
            floor.GetComponent<BoxCollider2D>().isTrigger = true;            
        }
    }

    void NotPassFloor(GameObject[] floors)
    {
        foreach (GameObject floor in floors)
        {
            floor.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    public static Color GetColor(GameObject obj)
    {
        return obj.GetComponent<SpriteRenderer>().color;
    }

    private void DieZone()
    {
        if (Switch_PlayerController.isDie)
        {
            player.transform.position = respawn.transform.position;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Switch_PlayerController.isDie = false;
            txtDeathCounter.text = $"Deaths: {++deathCounter}";
        }
    }

    private void NextStage()
    {
        if (Switch_PlayerController.nextStage)
        {
            Switch_PlayerController.nextStage = false;
            txtScoreboard.text = $"Flowers: {++scoreboard}";
            SaveSceneData();
            SceneManager.LoadScene(nextStage);
        }
    }

    private void LoadSceneData()
    {
        if (Switch_SceneManager.deathCounter >= 0)
        {
            deathCounter = Switch_SceneManager.deathCounter;
        }
        if (Switch_SceneManager.scoreboard >= 0)
        {
            scoreboard = Switch_SceneManager.scoreboard;
        }
    }

    private void SaveSceneData()
    {
        Switch_SceneManager.deathCounter = deathCounter;
        Switch_SceneManager.scoreboard = scoreboard;
    }

    private void ResetGame()
    {
        deathCounter = 0;
        scoreboard = 0;
        SaveSceneData();
    }

}
