using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_PlayerController : MonoBehaviour
{

    private GameObject player;

    private Vector2 velocity;

    private Vector2 xVelocity;
    public float xSpeed = 5f;

    private Vector2 yVelocity;

    public float maxHeight = 2f;
    private float jumpSpeed;
    public float timeToPeak = 0.3f;

    private float gravity;

    private void Awake()
    {
        player = GetComponent<Transform>().gameObject;

        gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak, 2);

        jumpSpeed = gravity * timeToPeak;

    }

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        xVelocity = xSpeed * xInput * Vector2.right;

        yVelocity += gravity * Time.deltaTime * Vector2.down;

        if (player.GetComponent<CharacterController>().isGrounded)
        {
            yVelocity = Vector2.down;
        }

        if (Input.GetKeyDown(KeyCode.W) && player.GetComponent<CharacterController>().isGrounded)
        {
            yVelocity = jumpSpeed * Vector2.up;
        }

        velocity = xVelocity + yVelocity;

        player.GetComponent<CharacterController>().Move(velocity * Time.deltaTime);

        ChangeColor();

    }

    void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Switch_GameManager.GetColor(player) == (new Color(0, 0, 0.7f, 1)))
            {
                Debug.Log("O player está azul, troque para vermelho");
                player.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0, 0, 1);
            }
            else
            {
                Debug.Log("O player está vermelho, troque para azul");
                player.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0.7f, 1);
            }
        }

    }
}
