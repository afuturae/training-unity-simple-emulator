using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{

    readonly float velocity = 600f;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate() {
        rb2d.velocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.S)) {
            rb2d.velocity = new Vector2(0, -1) * velocity * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.W)) {
            rb2d.velocity = new Vector2(0, 1) * velocity * Time.deltaTime;
        }
    }

}
