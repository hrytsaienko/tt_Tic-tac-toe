using System;

public class ComputerController
{
    public int NextMove(Cell[] cells, string xo)
    {
        string opponent;
        if (xo == "X")
            opponent = "O";
        else
            opponent = "X";

        int isFilledByOpponent = 0, isFilled = 0;
        int secondVariant = 0;
        int variant = 0, nextCellIter = 0;
        bool isVariant = false;
        bool isSecondVariant = false;
        bool isNext = false;

        //
        for (int i = 0; i < WinRows.winningRows.Length; i++)
        {
            variant = 0;
            isFilledByOpponent = 0;
            isFilled = 0;
            isVariant = false;

            for (int j = 0; j < 3; j++)
            {
                string cellText = cells[WinRows.winningRows[i][j]].GetText();

                if (cellText == opponent)
                {
                    isFilledByOpponent++;
                }
                else if (cellText == xo)
                {
                    isFilled++;
                }
                else if (cellText == "")
                {
                    variant = WinRows.winningRows[i][j];
                    isVariant = true;
                }
                else
                    isVariant = false;

            }

            if (isFilled == 2 && isVariant)
            {
                return variant;
            }

            if (isFilledByOpponent == 2 && isVariant)
            {
                nextCellIter = variant;
                isNext = true;
            }

            if (i == WinRows.winningRows.Length - 1 && isNext)
            {
                return nextCellIter;
            }

            else if (isFilled == 1)
            {
                secondVariant = variant;
                isSecondVariant = true;
            }
        }

        //if after allchecks there is no variant -> use randome
        if (isSecondVariant)
        {
            return secondVariant;            
        }
        else
        {
            secondVariant = RendomNextMove(cells);
            return secondVariant;
        }
    }

    public int RendomNextMove(Cell[] cells)
    {
        int[] emptyCells = new int[9];
        int iter = 0;
        Random random = new Random();
        
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].GetText() == "")
            {
                emptyCells[iter] = i;
                iter++;
            }                
        }

        int value = emptyCells[random.Next(0, iter)];
        return value;
    }

    public int StrategyNextMove(Cell[] cells, string xo)
    {
        string opponent;
        if (xo == "X")
            opponent = "O";
        else
            opponent = "X";


        int isFilledByOpponent = 0, isFilled = 0;
        int variant = 0, nextCellIter = 0;
        bool isVariant = false;
        bool isNext = false;


        //for very first move
        if (cells[4].IsEmpty() && cells[0].IsEmpty() && cells[2].IsEmpty() && cells[6].IsEmpty() && cells[8].IsEmpty())
        {
            return 0;
        }

        for (int i = 0; i < WinRows.winningRows.Length; i++)
        {
            variant = 0;
            isFilledByOpponent = 0;
            isFilled = 0;
            isVariant = false;
            

            for (int j = 0; j < 3; j++)
            {
                string cellText = cells[WinRows.winningRows[i][j]].GetText();

                if (cellText == opponent)
                {
                    isFilledByOpponent++;
                }
                else if (cellText == xo)
                {
                    isFilled++;
                }
                else if (cellText == "")
                {
                    variant = WinRows.winningRows[i][j];
                    isVariant = true;
                }
                else
                    isVariant = false;
            }

            if (isFilled == 2 && isVariant)
            {
                return nextCellIter = variant;
            }

            if (isFilledByOpponent == 2 && isVariant)
            {
                nextCellIter = variant;
                isNext = true;
            }

            if (i == WinRows.winningRows.Length - 1 && isNext)
            {
                return nextCellIter;
            }
        }

        //for second mome after opponent
        if (cells[4].GetText() == opponent)       //if opponent made his first move in the center
        {
            if (cells[0].IsEmpty())
                return 0;
            else if (cells[8].IsEmpty())
                return 8;
            else if (cells[6].IsEmpty())
                return 6;
            else if (cells[2].IsEmpty())
                return 2;
        }
        else if (cells[0].GetText() == opponent || cells[0].IsEmpty())
            if (cells[2].GetText() == opponent || cells[2].IsEmpty())
                if (cells[6].GetText() == opponent || cells[6].IsEmpty())
                    if (cells[8].GetText() == opponent || cells[8].IsEmpty())
                    {
                        if (cells[0].IsEmpty() && cells[2].IsEmpty() && cells[6].IsEmpty() && cells[8].IsEmpty())
                            return 0;
                        else if (cells[4].IsEmpty())
                            return 4;
                        else if (cells[1].IsEmpty())
                            return 1;
                        else if (cells[3].IsEmpty())
                            return 3;
                        else if (cells[5].IsEmpty())
                            return 5;
                        else if (cells[7].IsEmpty())
                            return 7;
                    }
        if (cells[0].IsEmpty())
            return 0;
        else if (cells[8].IsEmpty())
            return 8;
        else if (cells[6].IsEmpty())
            return 6;
        else if (cells[2].IsEmpty())
            return 2;


        //nothing works
        return 0;
    }

}
