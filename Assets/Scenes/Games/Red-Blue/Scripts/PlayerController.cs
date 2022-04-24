using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float velocity = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * velocity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * velocity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {

        if (GameController.GetColor(player) == (new Color(0, 0.7f, 0, 1)))
        {
            
            Debug.Log("A bola está azul, troque para vermelho");
        }
        else
        {
            Debug.Log("A bola está vermelho, troque para azul");
        }

    }
}
