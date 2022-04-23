using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static bool isPoint = false;
    public TMP_Text scoreboard;
    private static int[] scoreboardIndex;

    public static void playerOnePoint() {
        scoreboardIndex[0] = ++scoreboardIndex[0];
        isPoint = true;
    }
    public static void playerTwoPoint() {
        scoreboardIndex[1] = ++scoreboardIndex[1];
        isPoint = true;
    }

    void Awake() {
       scoreboardIndex = new int[] {0, 0};    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = string.Format(
                                        "{0}x{1}",
                                        scoreboardIndex[0],
                                        scoreboardIndex[1]
                                        );
    }
}
