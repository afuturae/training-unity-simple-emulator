using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_PlayerController : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    public float xSpeed = 10f;

    private float direction;

    private float jumpSpeed = 20f;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundLayer;

    private float gravity;

    public float maxHeight;

    public float timeToPeak;

    public static bool isDie;

    public static bool nextStage;

    private void Awake()
    {
        player = GetComponent<Transform>().gameObject;

        gravity = (2 * maxHeight) / (Mathf.Pow(timeToPeak, 2));

        jumpSpeed = gravity * timeToPeak;

        player.GetComponent<Rigidbody2D>().gravityScale = Mathf.Abs(gravity / Physics2D.gravity.magnitude);

    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            Jump();
        }

        ChangeColor();

    }

    private void FixedUpdate()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * xSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
    }

    void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Switch_GameManager.GetColor(player) == (new Color(0, 0, 0.7f, 1)))
            {
                player.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0, 0, 1);
            }
            else
            {
                player.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0.7f, 1);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Switch_DieZone"))
        {
            isDie = true;
        }

        if (collider.CompareTag("Switch_Flower"))
        {
            nextStage = true;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Jump()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
    }
}
