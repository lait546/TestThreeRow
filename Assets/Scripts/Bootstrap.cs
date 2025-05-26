using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void Start()
    {
        Application.targetFrameRate = 90;

        GameLogic.Start();
        _spawner.Spawn();

        GameLogic.OnRestart += _spawner.Spawn;
    }
}
