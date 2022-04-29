using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaders_EnemyController : MonoBehaviour
{

    [SerializeField] public Transform enemy_explosion;
    public Transform currentEnemyPosition;

    private void Start() {
        currentEnemyPosition = gameObject.transform;
    }

    private void OnTriggerEnter2D(Collider2D collisor) {
        Debug.Log(collisor.name);
        if(collisor.name == "shot(Clone)"){
            Instantiate(enemy_explosion, currentEnemyPosition.position, currentEnemyPosition.rotation);
            Destroy(gameObject, 0f);
        }
    }

}
