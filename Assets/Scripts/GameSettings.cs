using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings", fileName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public static GameSettings Get() => Resources.Load<GameSettings>("GameSettings");
}
