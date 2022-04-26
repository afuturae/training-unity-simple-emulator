using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float velocity = 600f;
    private Vector3 direction;
    public Transform ballTransform;
    public Rigidbody2D rb2d;

    void GenerateNewDirection() {
        direction = new Vector2(
            Random.Range(0.1f, 1),
            Random.Range(0.1f, 1)
        );
    }

    void Reset() {
        ballTransform.position = new Vector3(0,0,0);
        GenerateNewDirection();
    }

    void Awake() {
        GenerateNewDirection();
    }

    // Start is called before the first frame update
    void Start()
    {
        direction.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PingPongGameController.isPoint) {
            Reset();
            PingPongGameController.isPoint = false;
        }
        if(!PingPongGameController.isPause){
            ballTransform.position += direction * velocity * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collisor) {
        Vector2 normal = collisor.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal);
        direction.Normalize();
    }

}
