using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Text winnerText;
    [SerializeField]
    private GameManager gameManager;

    public void SetGameOver()
    {
        gameOverPanel.SetActive(!gameOverPanel.activeSelf);
    }

    public void SetPausePanel()
    {
        pausePanel.SetActive(!gameOverPanel.activeSelf);
    }

    public void SetWinnerText(string winner)
    {
        winnerText.text = winner;
    }

    public void LoadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

    public void NewGame()
    {
        gameManager.Restart();
        SetGameOver();
    }
}
