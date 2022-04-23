using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{

    readonly float velocity = 6f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.S) && player.position.y >= -4) {
            player.Translate(new Vector2(0, -1) * velocity * Time.deltaTime);
        } else if(Input.GetKey(KeyCode.W) && player.position.y <= 4) {
            player.Translate(new Vector2(0, 1) * velocity * Time.deltaTime);
        }
    }

}
