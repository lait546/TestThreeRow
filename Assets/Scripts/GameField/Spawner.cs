using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform container;

    private BoxCollider2D boxCollider;
    private int _counter = 0;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Spawn()
    {
        _counter = 0;
        StopAllCoroutines();
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        List<FigureItem> list = new List<FigureItem>();

        for(int i = 0; i < Figures.Get().ColorItems.Count; i++)
        {
            for (int j = 0; j < Figures.Get().FigureItems.Count; j++)
            {
                FigureItem figureItem = new FigureItem();

                figureItem.FigureColor = Figures.Get().ColorItems[i].FigureColor;
                figureItem.FigureType = Figures.Get().FigureItems[j].FigureType;
                figureItem.AnimalType = Figures.Get().AnimalItems[Random.Range(0, Figures.Get().AnimalItems.Count)].AnimalType;

                for (int k = 0; k < 3; k++)
                    list.Add(figureItem);
            }
        }

        list.Shuffle();

        while (_counter < list.Count)
        {
            float halfWidth = boxCollider.size.x * 0.5f;
            float halfHeight = boxCollider.size.y * 0.5f;

            Vector2 randomPosition = new Vector2(
                Random.Range(transform.position.x - halfWidth, transform.position.x + halfWidth),
                Random.Range(transform.position.y - halfHeight, transform.position.y + halfHeight));

            Figure figure = Figure.Create(list[_counter].FigureColor, list[_counter].FigureType, list[_counter].AnimalType, randomPosition, container);

            TryFrozenFigure(figure);

            _counter++;
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void TryFrozenFigure(Figure figure)
    {
        if (Random.Range(0, 10) <= 2)
        {
            IFigure decoratedFigure = new FrozenFigure(figure);
        }
    }
}
