using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch_MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject boxControls;    

    public void StartGame()
    {
        SceneManager.LoadScene("Switch_Stage1");
    }

    public void Controls()
    {
        boxControls.SetActive(!boxControls.activeSelf);
    }

    public static void QuitGame()
    {
        GameManager.BackToMenu();
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene("Switch_Home");
    }
}
