using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenFigure : FigureDecorator
{
    public FrozenFigure(IFigure figure) : base(figure) {
        this.CanPress = false;
        GameLogic.OnCurMovesChanged += DeFrozen;

        Frozen(figure);
    }

    public override void UpdateFigure(bool activeEffect)
    {
        this.CanPress = false;
        base.UpdateFigure(activeEffect);
    }

    private void Frozen(IFigure figure)
    {
        UpdateFigure(false);
    }

    private void DeFrozen()
    {
        if (GameLogic.CurrentCountMoves >= 15)
        {
            GameLogic.OnCurMovesChanged -= DeFrozen;
            CanPress = true;
            UpdateFigure(true);
        }
        else
        {
            UpdateFigure(false);
            CanPress = false;
        }
    }

    public override void Destroy()
    {
        base.Destroy();
    }

    public void OnDestroy()
    {
        GameLogic.OnCurMovesChanged -= DeFrozen;
    }
}
