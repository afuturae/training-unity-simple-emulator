using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPlayerTwo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        PingPongGameController.PlayerTwoPoint();
    }
}
