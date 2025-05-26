using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Figures", fileName = "Figures")]
public class Figures : ScriptableObject
{
    public Figure FigurePref;
    public Sprite FrozenSprite;

    public List<Figure> FigureItems = new List<Figure>();
    public List<AnimalItem> AnimalItems = new List<AnimalItem>();
    public List<ColorItem> ColorItems = new List<ColorItem>();

    public static Figures Get() => Resources.Load<Figures>("Figures");

    [HideInInspector] public static List<Figure> AllCreated = new List<Figure>();

    public static Action<int> AllCountChanged;

    public static void RemoveFromAllCreated(Figure figure)
    {
        AllCreated.Remove(figure);

        AllCountChanged?.Invoke(AllCreated.Count);
    }

    public static void RemoveAll()
    {
        for (int i = AllCreated.Count - 1; i >= 0; i--)
            Destroy(AllCreated[i].gameObject);

        AllCreated.Clear();
    }
}

public class FigureItem
{
    public FigureType FigureType;
    public AnimalType AnimalType;
    public FigureColor FigureColor;
}

[Serializable]
public class AnimalItem
{
    public Sprite SpriteAnimal;
    public AnimalType AnimalType;
}

[Serializable]
public class ColorItem
{
    public Color Color;
    public FigureColor FigureColor;
}

public enum FigureColor
{
    Red, Green, Blue, Yellow, Marine
}

public enum FigureType
{
    Circle, Square, Triangle, Squircle
}

public enum AnimalType
{
    Buffalo, Cat, Dog, Hadgehog, Kangaroo, Lama, Panda, Snake, Turtle, Unicorn
}
