using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour
{
    [SerializeField]
    private Button simple;
    [SerializeField]
    private Button normal;
    [SerializeField]
    private Button hard;

    void Awake()
    {
        simple.onClick.AddListener(() => LoadGame(GameLevel.Simple));
        normal.onClick.AddListener(()=> LoadGame(GameLevel.Normal));
        hard.onClick.AddListener(() => LoadGame(GameLevel.Hard));
    }

    public void LoadGame(GameLevel level)
    {
        GameManager.gameLevel = level;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
