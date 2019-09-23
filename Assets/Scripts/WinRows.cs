using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WinRows
{
    public static readonly int[][] winningRows = new int[8][]
    {
        new int[] {0, 1, 2},        //0
        new int[] {3, 4, 5},        //1
        new int[] {6, 7, 8},        //2
        new int[] {0, 3, 6},        //3
        new int[] {1, 4, 7},        //4
        new int[] {2, 5, 8},        //5
        new int[] {0, 4, 8},        //6
        new int[] {2, 4, 6},        //7
    };

    public static readonly int[][] winnigNumbsForCell = new int[9][]
    {
        new int[] { 0, 6, 3 },
        new int[] { 0, 4 },
        new int[] { 0, 5, 7 },
        new int[] { 1, 3 },
        new int[] { 1, 4, 6, 7 },
        new int[] { 5, 2 },
        new int[] { 2, 3, 7 },
        new int[] { 2, 4 },
        new int[] { 2, 5, 6 },
    };

    
}
