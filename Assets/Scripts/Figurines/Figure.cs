using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Figure : MonoBehaviour, IFigure
{
    [SerializeField] private SpriteRenderer _animal, _border, _background, _effect;

    public bool CanPress { get; set; } = true;
    public FigureColor FigureColor { get; private set; }
    public AnimalType AnimalType { get; private set; }
    [field: SerializeField] public FigureType FigureType { get; private set; }

    public static Figure Create(FigureColor color, FigureType figureType, AnimalType animal, Vector2 pos, Transform container)
    {
        AnimalItem animalItem = Figures.Get().AnimalItems.Find(x => x.AnimalType == animal);
        Color colorItem = Figures.Get().ColorItems.Find(x => x.FigureColor == color).Color;

        Figure figure = Instantiate(Figures.Get().FigureItems.Find(x => x.FigureType == figureType), pos, Quaternion.identity);
        figure.transform.SetParent(container);

        figure._animal.sprite = animalItem.SpriteAnimal;
        figure._background.color = colorItem;

        figure.FigureColor = color;
        figure.AnimalType = animal;
        figure.FigureType = figureType;

        Figures.AllCreated.Add(figure);

        return figure;
    }

    public void OnMouseDown()
    {
        if (CanPress)
            if (!EventSystem.current.IsPointerOverGameObject())
                SelectedPanel.Instance.AddFigure(this);
    }

    public void UpdateFigure(bool activeEffect)
    {
        _effect.gameObject.SetActive(!activeEffect);
        CanPress = activeEffect;
    }

    public void Destroy()
    {
        Sequence sequence = DOTween.Sequence();

        float averageScale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3f;

        Figures.RemoveFromAllCreated(this);

        sequence.Append(transform.DOScale(averageScale * 1.4f, 0.5f)).Append(transform.DOScale(0f, 0.5f)).OnComplete(() => Destroy(gameObject));
    }

    public void MoveTo(Vector3 pos, float moveTime)
    {
        GetComponent<Rigidbody2D>().simulated = false;
        transform.DORotate(Vector3.zero, moveTime);
        transform.DOMove(pos, moveTime);
    }
}