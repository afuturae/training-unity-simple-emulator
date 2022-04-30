using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SpaceInvaders_GameController : MonoBehaviour
{

    public static float enemyVelocity = 100f;
    public static float playerVelocity = 450f;
    public GameObject spawn;
    [SerializeField] public Transform player;

    [SerializeField] public Transform enemy;
    public Canvas canvasMenu;
    static TMP_Text info;

    private BoxCollider2D boxCollider;
    private static bool isPause = false;
    private float spawnFrequency = 2f;


    private void Awake() {

        var gameObj = GameObject.Find("GameManager").transform
                .Find("canvas_menu").transform
                .Find("menu_info").GetComponent<TMP_Text>();

        info = gameObj;

        boxCollider = spawn.GetComponent<BoxCollider2D>();
        Time.timeScale = 0;
        isPause = true;
        info.text = "Space Invaders";
        canvasMenu.gameObject.SetActive(true);
    }

    private void GenerateEnemy() {
        float coordinateX = Random.Range(0, boxCollider.size[0]/2);
        float coordinatey = Random.Range(spawn.transform.position.y, boxCollider.size[1]/2 + spawn.transform.position.y);
        Vector2 enemyCoordinate = new Vector2(coordinateX, coordinatey);
        Instantiate(enemy, enemyCoordinate, enemy.rotation);
    }

    private void SpawnEnemies () {
        InvokeRepeating("GenerateEnemy", 0.4f, spawnFrequency);
    }

    private void Start() {
        SpawnEnemies();
    }

    public static void Dead() {

         GameObject[] particles;
         GameObject[] enemies;
         GameObject[] shots;
 
        particles = GameObject.FindGameObjectsWithTag("particles");
        enemies = GameObject.FindGameObjectsWithTag("enemies");
        shots = GameObject.FindGameObjectsWithTag("shots");

        foreach(GameObject particle in particles)
        {
            Destroy(particle);
        }
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        foreach(GameObject shot in shots)
        {
            Destroy(shot);
        }

        isPause = true;
        info.text = "Você morreu!";
        Time.timeScale = 0;
    }
    private void Update() {
        if(isPause){
            canvasMenu.gameObject.SetActive(true);
            if(Input.GetKey(KeyCode.W)){
                Instantiate(player, new Vector3(0, -4.58f, 0),Quaternion.identity);
                isPause = false;
                canvasMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            if(Input.GetKey(KeyCode.F1)) {
                isPause = false;
                Time.timeScale = 1;
                GameManager.BackToMenu();
            }
        }
    }

}
