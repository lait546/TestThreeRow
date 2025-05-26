using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPanel : MonoBehaviour
{
    public static SelectedPanel Instance;

    public RectTransform rect;
    public List<RectTransform> UiCells = new List<RectTransform>();
    public List<Figure> Figures = new List<Figure>();
    public Action FigureAdded;

    public void Awake()
    {
        Instance = this;
    }

    public void AddFigure(Figure figure)
    {
        float moveTime = 0.5f;
        FigureAdded?.Invoke();

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(
                rect,
                UiCells[Figures.Count].position,
                Camera.main,
                out var worldPos))
        {
            figure.MoveTo(worldPos, moveTime);
        }

        Figures.Add(figure);

        StartCoroutine(CheckFigures(moveTime));
    }

    public IEnumerator CheckFigures(float delay)
    {
        yield return new WaitForSeconds(delay);

        int counter = 0;
        List<Figure> figures = new List<Figure>();

        for (int i = 0; i < Figures.Count; i++)
        {
            counter = 0;

            figures.Clear();
            figures.Add(Figures[i]);

            for (int j = 0; j < Figures.Count; j++)
            {
                if (Figures[i] != Figures[j] && 
                   (Figures[i].FigureType == Figures[j].FigureType && Figures[i].AnimalType == Figures[j].AnimalType && Figures[i].FigureColor == Figures[j].FigureColor))
                {
                    counter++;
                    figures.Add(Figures[j]);
                    
                    if (counter >= 2)
                    {
                        DestroyFigures(figures);
                        StartCoroutine(RestructurePositions());
                    }
                }
            }
        }

        if (Figures.Count >= UiCells.Count)
        {
            EndGameWindow.Instance.End(false);
        }
    }

    private IEnumerator RestructurePositions()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < Figures.Count; i++)
        {
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(
               rect,
               UiCells[i].position,
               Camera.main,
               out var worldPos))
            {
                Figures[i].MoveTo(worldPos, 0.5f);
            }
        }
    }

    public void DestroyFigures(List<Figure> figures)
    {
        for (int i = 0; i < figures.Count; i++)
        {
            Figures.Remove(figures[i]);

            figures[i].Destroy();
        }
    }

    public void ClearLists()
    {
        Figures.Clear();
    }
}
