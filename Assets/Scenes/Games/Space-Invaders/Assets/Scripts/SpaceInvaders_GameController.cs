using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SpaceInvaders_GameController : MonoBehaviour
{

    public static float enemyVelocity = 90f;
    public static float playerVelocity = 450f;
    public GameObject spawn;

    [SerializeField] public Transform enemy;
    public Canvas canvasMenu;
    public TMP_Text info;

    private BoxCollider2D boxCollider;
    private bool isPause = false;

    private void Awake() {
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

    private void Update() {
        if(isPause){
            if(Input.GetKey(KeyCode.Space)){
                Debug.Log("APERTOU");
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
