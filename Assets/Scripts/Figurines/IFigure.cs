using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;

public interface IFigure
{
    bool CanPress { get; set; }
    void UpdateFigure(bool activeEffect);
    void Destroy();
}
