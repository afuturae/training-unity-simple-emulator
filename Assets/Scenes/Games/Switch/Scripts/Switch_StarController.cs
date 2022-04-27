using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_StarController : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    public float speedR;
    int i;

    void Awake()
    {
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GetComponent<Transform>().RotateAround(transform.position, new Vector3(0,0,1), speedR*Time.deltaTime);

        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
