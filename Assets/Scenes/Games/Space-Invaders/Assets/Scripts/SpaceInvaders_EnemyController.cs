using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaders_EnemyController : MonoBehaviour
{

    [SerializeField] public Transform enemy_explosion;
    private Transform currentEnemyPosition;
    private Rigidbody2D rb2d;

    private void Start() {
        currentEnemyPosition = gameObject.transform;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb2d.velocity = new Vector2(0, -1) * SpaceInvaders_GameController.enemyVelocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collisor) {
        if(collisor.name == "trigger_down"){
            SpaceInvaders_GameController.Damage();
            Destroy(gameObject, 0f);
        }
        if(collisor.name == "shot(Clone)"){
            SpaceInvaders_GameController.Point();
            Instantiate(enemy_explosion, currentEnemyPosition.position, currentEnemyPosition.rotation);
            Destroy(gameObject, 0f);
        }
    }

}
