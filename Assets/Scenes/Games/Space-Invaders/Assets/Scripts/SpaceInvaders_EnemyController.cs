using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaders_EnemyController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collisor) {
        Debug.Log(collisor.name);
        if(collisor.name == "shot(Clone)"){
            Destroy(gameObject, 0f);
        }
    }

}
