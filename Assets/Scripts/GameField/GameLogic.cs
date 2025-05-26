using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic
{
    public static int CurrentCountMoves = 0;
    public static Action OnCurMovesChanged, OnRestart;

    public static void Start()
    {
        
    }

    public static void Restart()
    {
        Figures.RemoveAll();
        CurrentCountMoves = 0;
        OnRestart?.Invoke();
        OnCurMovesChanged = null;
    }

    public static void ChangeCurMoves()
    {
        CurrentCountMoves++;
        OnCurMovesChanged?.Invoke();
    }
}
