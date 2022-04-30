using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaders_shot : MonoBehaviour
{
    readonly float velocity = 5f;

    void Update() {
        transform.position += new Vector3(0, 1, 0) * velocity * Time.deltaTime;        
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collisor) {
        if(collisor.name == "SpaceInvaders_enemy(Clone)") {
            Destroy(gameObject, 0f);
        }
    }

}
