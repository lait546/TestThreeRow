using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameWindow : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private TextMeshProUGUI _rslt;

    public void Awake()
    {
        Figures.AllCountChanged += TryEnd;
        SelectedPanel.OnFigureFull += Lose;
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

    public void Lose()
    {
        _window.SetActive(true);
        _rslt.text = "Lose.";
    }

    public void ResetGame()
    {
        _window.SetActive(false);
        GameLogic.Restart();
    }
}
