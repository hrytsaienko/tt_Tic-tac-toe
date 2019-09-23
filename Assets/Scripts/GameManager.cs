using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject grid;
    [SerializeField]
    private Text plaerScore;
    [SerializeField]
    private Text computerScore;
    [SerializeField]
    private Button playerButton;
    [SerializeField]
    private Text playerButtonText;
    [SerializeField]
    private Button computerButton;    
    [SerializeField]
    private Text computerButtonText;

    private GridManagar gridManagar;
    private SceneManager sceneManager;
    private string playerSide;

    private bool computerTurn = false;
    private bool xTurn = true;
    private int turnCount = 0;
    private int playerCount = 0;
    private int aiCount = 0;
    private ComputerController computer;
    public static GameLevel gameLevel = GameLevel.Hard;

    private void Awake()
    {
        plaerScore.text = "0";
        computerScore.text = "0";

        playerButton.interactable = computerButton.interactable = false;

        gridManagar = grid.GetComponent<GridManagar>();
        gridManagar.BuildGrid(this);
        computer = new ComputerController();
        sceneManager = GetComponent<SceneManager>();

        if (gameLevel == GameLevel.Hard)
        {
            computerTurn = true;
            ComputerMove();

            computerButtonText.text = "X";
            playerButtonText.text = "O";
        }  
        else
        {
            computerButtonText.text = "O";
            playerButtonText.text = "X";
        }
    }

    private void FixedUpdate()
    {
        plaerScore.text = playerCount.ToString();
        computerScore.text = aiCount.ToString();
    }

    #region GameOver

    private void Draw()
    {
        GameOver("");

        computerTurn = !computerTurn;

        if (computerTurn)
        {
            computerButtonText.text = "X";
            playerButtonText.text = "O";
        }
        else
        {
            computerButtonText.text = "O";
            playerButtonText.text = "X";
        }
        Debug.Log("_____Draw________");        
    }

    private void Win()
    {
        //Count; Check X Y; Game Over
        if (computerTurn)
        {
            aiCount++;
            GameOver("Computer");
        }
        else
        {
            playerCount++;
            GameOver("Player");
        }
        Debug.Log(playerSide + "    You Won!");
    }

    private void GameOver(string winner)
    {
        if (computerTurn && winner != "")
        {
            // computer won
            sceneManager.SetWinnerText("You lose =(");

            computerTurn = true;
            computerButtonText.text = "X";
            playerButtonText.text = "O";
        }
        else if (winner != "")
        {
            //player won
            sceneManager.SetWinnerText("You win!");
        }
        else
        {
            //Draw
            sceneManager.SetWinnerText("Draw");
        }

        sceneManager.SetGameOver();
    }

    public void Restart()
    {
        xTurn = true;
        turnCount = 0;

        //restart grid
        foreach (Cell cell in gridManagar.GetCells())
        {
            cell.ResetCell();
        }

        if (computerTurn)
        {
            ComputerMove();
        }
    }
    #endregion

    public void CheckWin(int cellNamber)
    {
        turnCount++;

        if (CheckWinRows(cellNamber))
        {
            Win();
        }        
        else if (turnCount == 9)
        {
            Draw();
        }
        else if (turnCount < 9)
        {
            Switch();
        }
    }        

    public bool CheckWinRows(int cellNamber)
    {
        playerSide = GetCharecterSide();

        int[] rowsForChecking = WinRows.winnigNumbsForCell[cellNamber];
        for (int i = 0; i < rowsForChecking.Length; i++)
        {
            int[] row = WinRows.winningRows[rowsForChecking[i]];
            if (gridManagar.GetCell(row[0]).GetText() == playerSide 
                && gridManagar.GetCell(row[1]).GetText() == playerSide 
                && gridManagar.GetCell(row[2]).GetText() == playerSide)
            {               
                return true;
            }
        }
        return false;
    }       

    public void Switch()
    {
        xTurn = !xTurn;
        computerTurn = !computerTurn;

        if(computerTurn)
        {
            ComputerMove();
        }
    }

    private void ComputerMove()
    {
        int nextCellIter = 0;

        if (gameLevel == GameLevel.Simple)
            nextCellIter = computer.RendomNextMove(gridManagar.GetCells());
        else if (gameLevel == GameLevel.Normal)
            nextCellIter = computer.NextMove(gridManagar.GetCells(), GetCharecterSide());
        else if ((gameLevel == GameLevel.Hard))
            nextCellIter = computer.StrategyNextMove(gridManagar.GetCells(), GetCharecterSide());

        gridManagar.GetCell(nextCellIter).Fill();
    }

    public void SetGameLevel(GameLevel setGameLevel)
    {
        gameLevel = setGameLevel;
    }

    public string GetCharecterSide()
    {
        if (xTurn)
        {
            return "X";
        }            
        else
        {
            return "O";
        }            
    }
}

public enum GameLevel
{
    Simple,
    Normal,
    Hard
}
