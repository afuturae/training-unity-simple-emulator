using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPlayerOne : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        PingPongGameController.PlayerOnePoint();
    }
}
