using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public GameObject floorBluePrefab;
    //public GameObject floorRedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] floorBlue;
        GameObject[] floorRed;
        floorBlue = GameObject.FindGameObjectsWithTag("Floor_Blue");
        floorRed = GameObject.FindGameObjectsWithTag("Floor_Red");
        Debug.Log($"Nesse estágio tem {floorBlue.Length} Azul e {floorRed.Length} Vermelho");
        foreach (GameObject floor in floorBlue) {
            floor.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
