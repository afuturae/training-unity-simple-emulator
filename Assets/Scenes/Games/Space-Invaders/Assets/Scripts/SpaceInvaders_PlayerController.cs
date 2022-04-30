using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaders_PlayerController : MonoBehaviour
{
    readonly float fireRate = 0.4f;
    float timer = 0f;
    public Rigidbody2D rb2d;
    [SerializeField] public Transform shot;
    [SerializeField] public Transform explosion;
    public Transform playerComponent;

    void Start() {
    }

    void FixedUpdate() {

        if(SpaceInvaders_GameController.lifesNumber <=0){
            Dead();
        }

        rb2d.velocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A)) {
            rb2d.velocity = new Vector2(-1, 0) * SpaceInvaders_GameController.playerVelocity * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.D)) {
            rb2d.velocity = new Vector2(1, 0) * SpaceInvaders_GameController.playerVelocity * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.Space) && timer <= 0){
            Instantiate(shot, playerComponent.position, Quaternion.identity);
            timer = fireRate;
        }else {
            timer -= Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            timer = 0;
        }
    }

    private void Dead() {
        Instantiate(explosion, playerComponent.position, playerComponent.rotation);
        Destroy(gameObject, 0f);
        SpaceInvaders_GameController.Dead();
    }

    private void OnCollisionEnter2D(Collision2D collisor) {
        if(collisor.collider.name == "SpaceInvaders_enemy(Clone)"){
            Dead();
        }
    }

}