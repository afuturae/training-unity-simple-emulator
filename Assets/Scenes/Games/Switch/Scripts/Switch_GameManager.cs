using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_GameManager : MonoBehaviour
{

    public GameObject player;

    [Header("Floors")]
    public GameObject floorBluePrefab;
    GameObject[] floorsBlue;
    
    public GameObject floorRedPrefab;
    GameObject[] floorsRed;

    // Start is called before the first frame update
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
            floor.GetComponent<BoxCollider>().isTrigger = true;            
        }
    }

    void NotPassFloor(GameObject[] floors)
    {
        foreach (GameObject floor in floors)
        {
            floor.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    public static Color GetColor(GameObject obj)
    {
        return obj.GetComponent<SpriteRenderer>().color;
    }
}
