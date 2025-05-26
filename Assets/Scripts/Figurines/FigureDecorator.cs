using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FigureDecorator : MonoBehaviour, IFigure
{
    public virtual bool CanPress { get; set; }
    protected IFigure wrappedFigure;

    public FigureDecorator(IFigure figure)
    {
        this.wrappedFigure = figure;
        this.CanPress = figure.CanPress;
    }

    public virtual void UpdateFigure(bool activeEffect)
    {
        wrappedFigure.UpdateFigure(activeEffect);
    }

    public virtual void Destroy()
    {
        wrappedFigure.Destroy();
    }
}
