using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Button cellButton;
    private Text cellText;
    public GameManager gameManager;
    public int CellIter { get; set; }

    private void Awake()
    {
        cellText = GetComponentInChildren<Text>();
        cellText.text = "";
    }
    public void Fill()
    {
        cellText.text = gameManager.GetCharecterSide();
        cellButton.interactable = false;
        gameManager.CheckWin(CellIter);
    }

    public string GetText()
    {
        return cellText.text;
    }

    public bool IsEmpty()
    {
        return cellText.text == "" ? true : false;
    }

    public void ResetCell()
    {
        cellButton.interactable = true;
        cellText.text = "";
    }
}
