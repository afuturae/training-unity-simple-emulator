using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public static class ButtonExtension {
    public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick) {
        button.onClick.AddListener(delegate() {
            OnClick(param);
        });
    }

}

public class MenuItemsBuilder : MonoBehaviour
{

    [System.Serializable]
    public struct MenuItem {
        public string name;
        public string description;
        public Sprite Icon;

        public string sceneName;
    }

    [SerializeField]
    public MenuItem[] games;

    void Start()
    {
        GameObject template = transform.GetChild(0).gameObject;
        GameObject instantiatedGame;
        for(int i = 0; i < games.Length; i ++) {
            instantiatedGame = Instantiate(template, transform);
            instantiatedGame.transform.GetChild(0).GetComponent<Image>().sprite = games[i].Icon;
            instantiatedGame.transform.GetChild(1).GetComponent<TMP_Text>().text = games[i].name;
            instantiatedGame.transform.GetChild(2).GetComponent<TMP_Text>().text = games[i].description;
            instantiatedGame.GetComponent<Button>().AddEventListener(i, OpenScene);

        }
        Destroy(template);
    }

    void OpenScene(int gameIndex) {
        Debug.Log("GameIndex: " + gameIndex);
        SceneManager.LoadScene(games[gameIndex].sceneName);
    }

}