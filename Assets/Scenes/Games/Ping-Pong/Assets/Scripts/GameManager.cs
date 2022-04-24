using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static bool isPoint = false;
    public static bool isPause = false;

    public Canvas canvasMenu;
    public TMP_Text scoreboard;
    public static TMP_Text info;
    private static int[] scoreboardIndex;

    private static void PauseGame() {
        isPause = true;
        Time.timeScale = 0;
    }

    private static void FinishGame() {
        scoreboardIndex = new int[] {0, 0};
    }

    public static void playerOnePoint() {
        scoreboardIndex[0] = ++scoreboardIndex[0];
        isPoint = true;
        if(scoreboardIndex[0] >= 5) {
            info.text = "Jogador 1 ganhou!";
            FinishGame();
        }else {
            info.text = "Ponto para o jogador 1";
        }
        PauseGame();
    }
    public static void playerTwoPoint() {
        scoreboardIndex[1] = ++scoreboardIndex[1];
        isPoint = true;
        if(scoreboardIndex[1] >= 5) {
            info.text = "Jogador 2 ganhou!";
            FinishGame();
        }else {
            info.text = "Ponto para o jogador 2";
        }
        PauseGame();
    }

    void Awake() {
        scoreboardIndex = new int[] {0, 0};
        canvasMenu.gameObject.SetActive(true);
        isPause = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        var gameObj = GameObject.Find("GameManager").transform
                      .Find("canvas_menu").transform
                      .Find("menu_info").GetComponent<TMP_Text>();
        Debug.Log(gameObj);
        info = gameObj;
        info.text = "O jogo está prestes a começar!";
    }

    // Update is called once per frame
    void Update()
    {
        if(isPause) {
            canvasMenu.gameObject.SetActive(true);
            if(Input.GetKey(KeyCode.Space)) {
                isPause = false;
                Time.timeScale = 1;
                canvasMenu.gameObject.SetActive(false);
            }
            if(Input.GetKey(KeyCode.F2)) {
                FinishGame();
                isPause = false;
                Time.timeScale = 1;
                canvasMenu.gameObject.SetActive(false);  
            }
        }

        if(Input.GetKey(KeyCode.Escape)) {
            info.text = "Jogo pausado - F2 para resetar o game!";
            isPause = true;
        }

        scoreboard.text = string.Format(
                                        "{0}x{1}",
                                        scoreboardIndex[0],
                                        scoreboardIndex[1]
                                        );
    }
}
