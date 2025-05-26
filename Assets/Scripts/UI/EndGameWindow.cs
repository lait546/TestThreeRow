using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameWindow : MonoBehaviour
{
    public static EndGameWindow Instance;

    [SerializeField] private GameObject _window;
    [SerializeField] private TextMeshProUGUI _rslt;

    public void Awake()
    {
        Instance = this;

        Figures.AllCountChanged += TryEnd;
    }

    public void TryEnd(int curFiguresCount)
    {
        if (curFiguresCount <= 0)
            End(true);
    }

    public void End(bool win)
    {
        _window.SetActive(true);

        if (win)
            _rslt.text = "Win!";
        else
            _rslt.text = "Lose.";
    }

    public void ResetGame()
    {
        _window.SetActive(false);
        GameLogic.Restart();
    }
}
