using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaders_GameController : MonoBehaviour
{

    public static float enemyVelocity = 90f;
    public static float playerVelocity = 450f;
    public GameObject spawn;

    [SerializeField] public Transform enemy;

    private BoxCollider2D boxCollider;

    private void Start() {
        boxCollider = spawn.GetComponent<BoxCollider2D>();
        GenerateEnemy();
    }

    private void GenerateEnemy() {
        float coordinateX = Random.Range(0, boxCollider.size[0]/2);
        float coordinatey = Random.Range(spawn.transform.position.y, boxCollider.size[1]/2 + spawn.transform.position.y);
        Vector2 enemyCoordinate = new Vector2(coordinateX, coordinatey);
        Instantiate(enemy, enemyCoordinate, enemy.rotation);
    }

    private void FixedUpdate() {
        
    }

}
