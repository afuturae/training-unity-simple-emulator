using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaders_PlayerController : MonoBehaviour
{
    readonly float velocity = 450f;
    readonly float fireRate = 0.4f;
    float timer = 0f;
    public Rigidbody2D rb2d;
    [SerializeField] public Transform shot;
    public Transform playerComponent;

    void Start() {
    }

    void FixedUpdate() {
        rb2d.velocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            rb2d.velocity = new Vector2(-1, 0) * velocity * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            rb2d.velocity = new Vector2(1, 0) * velocity * Time.deltaTime;
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

}