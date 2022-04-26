using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Switch_GameManager : MonoBehaviour
{

    public GameObject player;

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
        txtScoreboard.text = $"Score:{scoreboard}";
        txtDeathCounter.text = $"Deaths:{deathCounter}";
    }
    void Start()
    {
        floorsBlue = GameObject.FindGameObjectsWithTag("Floor_Blue");
        floorsRed = GameObject.FindGameObjectsWithTag("Floor_Red");
        Debug.Log($"Nesse estágio tem {floorsBlue.Length} Azul e {floorsRed.Length} Vermelho");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DetectFloor();
        DieZone();
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
            Debug.Log("Morreu");
            player.transform.position = respawn.transform.position;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Switch_PlayerController.isDie = false;
            txtDeathCounter.text = $"Deaths:{++deathCounter}";
        }
    }




}
