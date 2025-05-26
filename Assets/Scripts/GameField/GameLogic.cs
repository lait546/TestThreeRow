using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic
{
    public static int CurrentCountMoves = 0;
    public static Action CurMovesChanged;

    public static void Start()
    {
        SelectedPanel.Instance.FigureAdded += ChangeCurMoves;
    }

    public static void Restart()
    {
        Figures.RemoveAll();
        SelectedPanel.Instance.ClearLists();
        Spawner.Instance.Spawn();
        CurrentCountMoves = 0;
    }

    public static void ChangeCurMoves()
    {
        CurrentCountMoves++;
        CurMovesChanged?.Invoke();
    }
}
